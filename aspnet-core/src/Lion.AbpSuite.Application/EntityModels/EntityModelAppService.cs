namespace Lion.AbpSuite.EntityModels;

public class EntityModelAppService : AbpSuiteAppService, IEntityModelAppService
{
    private readonly EntityModelManager _entityModelManager;
    private readonly DataTypeManager _dataTypeManager;
    private readonly EnumTypeManager _enumTypeManager;

    public EntityModelAppService(EntityModelManager entityModelManager, DataTypeManager dataTypeManager, EnumTypeManager enumTypeManager)
    {
        _entityModelManager = entityModelManager;
        _dataTypeManager = dataTypeManager;
        _enumTypeManager = enumTypeManager;
    }

    public async Task<PagedResultDto<PageEntityModelPropertyOutput>> PagePropertyAsync(PageEntityModelInput input)
    {
        var result = new PagedResultDto<PageEntityModelPropertyOutput>();
        var entity = await _entityModelManager.FindAsync(input.Id);
        result.TotalCount = entity.EntityModelProperties.Count;
        var properties = entity.EntityModelProperties.WhereIf(
                input.Filter.IsNotNullOrWhiteSpace(),
                e => e.Code.Contains(input.Filter) || e.Description.Contains(input.Filter))
            .OrderByDescending(e => e.CreationTime)
            .Skip(input.SkipCount)
            .Take(input.PageSize)
            .ToList();
        if (result.TotalCount > 0)
        {
            var datatypes = await _dataTypeManager.ListAsync();
            var enumtypes = await _enumTypeManager.ListAsync(input.Id);
            var list = ObjectMapper.Map<List<EntityModelPropertyDto>, List<PageEntityModelPropertyOutput>>(properties);
            foreach (var item in properties)
            {
                if (item.DataTypeId.HasValue)
                {
                    var temp = list.First(e => e.Id == item.Id);
                    temp.DataTypeId = item.DataTypeId.Value;
                    temp.DataTypeDescription = datatypes.FirstOrDefault(e => e.Id == item.DataTypeId.Value)?.Description;
                    temp.DataTypeCode = datatypes.FirstOrDefault(e => e.Id == item.DataTypeId.Value)?.Code;
                }

                if (item.EnumTypeId.HasValue)
                {
                    var temp = list.First(e => e.Id == item.Id);
                    temp.DataTypeId = item.EnumTypeId.Value;
                    temp.DataTypeDescription = enumtypes.FirstOrDefault(e => e.Id == item.EnumTypeId.Value)?.Description;
                    temp.DataTypeCode = enumtypes.FirstOrDefault(e => e.Id == item.EnumTypeId.Value)?.Code;
                    temp.IsEnum = true;
                }
            }

            result.Items = list;
        }

        return result;
    }

    public Task CreateAggregateAsync(CreateAggregateInput input)
    {
        return _entityModelManager.CreateAggregateAsync(input.ProjectId, input.Code, input.Description);
    }

    public Task UpdateAggregateAsync(UpdateAggregateInput input)
    {
        return _entityModelManager.UpdateAggregateAsync(input.Id, input.Code, input.Description);
    }

    public Task DeleteAggregateAsync(DeleteAggregateInput input)
    {
        return _entityModelManager.DeleteAggregateAsync(input.Id);
    }

    public Task CreateEntityModelAsync(CreateEntityModelInput input)
    {
        return _entityModelManager.CreateEntityAsync(input.Id, input.Code, input.Description, input.RelationalType);
    }

    public Task UpdateEntityModelAsync(UpdateEntityModelInput input)
    {
        return _entityModelManager.UpdateEntityAsync(input.Id, input.Code, input.Description, input.RelationalType);
    }

    public Task DeleteEntityModelAsync(DeleteEntityModelInput input)
    {
        return _entityModelManager.DeleteEntityAsync(input.AggregateId, input.Id);
    }

    public Task CreateEntityModelPropertyAsync(CreateEntityModelPropertyInput input)
    {
        return _entityModelManager.CreatePropertyAsync(
            input.Id,
            input.Code,
            input.Description,
            input.IsRequired,
            input.MaxLength,
            input.MinLength,
            input.DecimalPrecision,
            input.DecimalScale,
            input.EnumTypeId,
            input.DataTypeId);
    }

    public Task UpdateEntityModelPropertyAsync(UpdateEntityModelPropertyInput input)
    {
        return _entityModelManager.UpdatePropertyAsync(
            input.Id,
            input.PropertyId,
            input.Code,
            input.Description,
            input.IsRequired,
            input.MaxLength,
            input.MinLength,
            input.DecimalPrecision,
            input.DecimalScale,
            input.EnumTypeId,
            input.DataTypeId);
    }

    public Task DeleteEntityModelPropertyAsync(DeleteEntityModelPropertyInput input)
    {
        return _entityModelManager.DeletePropertyAsync(input.Id, input.PropertyId);
    }

    public async Task<List<GetEntityModelTreeOutput>> EntityModelTreeAsync(GetEntityModelTreeInput input)
    {
        var list = await _entityModelManager.ListAsync(input.ProjectId);
        if (list.Count == 0) return new List<GetEntityModelTreeOutput>();
        return RecursionEntityModel(list, null);
    }

    public async Task<List<GetEntityModelOutput>> GetAsync(GetEntityModelInput input)
    {
        var entity = await _entityModelManager.FindAggregateAsync(input.Id);
        if (entity == null) throw new UserFriendlyException("实体不存在");
        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListAsync(input.Id);
        var result = RecursionEntity(entity, null, dataTypes, enumTypes);
        return result;
    }

    private List<GetEntityModelOutput> RecursionEntity(List<EntityModelDto> entities, Guid? parentId, List<DataTypeDto> dataTypes, List<EnumTypeDto> enumTypes)
    {
        var tree = new List<GetEntityModelOutput>();
        var list = entities.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            var child = new GetEntityModelOutput()
            {
                Id = detail.Id,
                Code = detail.Code,
                Description = detail.Description,
                RelationalType = detail.RelationalType,
            };
            foreach (var detailEntityModelProperty in detail.EntityModelProperties)
            {
                var property = new GetEntityModelPropertyOutput()
                {
                    Id = detailEntityModelProperty.Id,
                    Code = detailEntityModelProperty.Code,
                    Description = detailEntityModelProperty.Description,
                    IsRequired = detailEntityModelProperty.IsRequired,
                    MaxLength = detailEntityModelProperty.MaxLength,
                    MinLength = detailEntityModelProperty.MinLength,
                    DecimalPrecision = detailEntityModelProperty.DecimalPrecision,
                    DecimalScale = detailEntityModelProperty.DecimalScale,
                    EnumTypeId = detailEntityModelProperty.EnumTypeId,
                    IsEnum = detailEntityModelProperty.EnumTypeId.HasValue ? true : false,
                    DataTypeId = detailEntityModelProperty.DataTypeId,
                    EntityModelId = detailEntityModelProperty.EntityModelId,
                };
                if (property.IsEnum)
                {
                    var currentEnum = enumTypes.FirstOrDefault(e => property.EnumTypeId != null && e.Id == property.EnumTypeId.Value);
                    if (currentEnum != null)
                    {
                        property.EnumTypeOutput = new GetEnumTypeOutput()
                        {
                            Id = currentEnum.Id,
                            Code = currentEnum.Code,
                            Description = currentEnum.Description
                        };
                    }
                 
                }
                else
                {
                    var currentdata = dataTypes.FirstOrDefault(e => property.DataTypeId != null && e.Id == property.DataTypeId.Value);
                    if (currentdata != null)
                    {
                        property.DataTypeOutput = new GetDataTypeOutput()
                        {
                            Id = currentdata.Id,
                            Code = currentdata.Code,
                            Description = currentdata.Description
                        }; 
                    }
            
                }

                child.EntityModelProperties.Add(property);
            }

            child.EntityModelOutputs.AddRange(RecursionEntity(entities, detail.Id, dataTypes, enumTypes));
            tree.Add(child);
        }

        return tree;
    }

    private List<GetEntityModelTreeOutput> RecursionEntityModel(List<EntityModelDto> entities, Guid? parentId)
    {
        var tree = new List<GetEntityModelTreeOutput>();
        var list = entities.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            var child = new GetEntityModelTreeOutput()
            {
                Key = detail.Id,
                Title = detail.Code,
                Description = detail.Description,
                Code = detail.Code,
                ParentId = detail.ParentId,
                RelationalType = detail.RelationalType
            };
            child.Children.AddRange(RecursionEntityModel(entities, detail.Id));
            tree.Add(child);
        }

        return tree;
    }
}