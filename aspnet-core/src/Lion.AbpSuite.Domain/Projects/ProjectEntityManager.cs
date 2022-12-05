using Lion.AbpSuite.DataTypes;
using Lion.AbpSuite.EntityModels;
using Lion.AbpSuite.Projects.Dto.Generators;

namespace Lion.AbpSuite.Projects;

public class ProjectEntityManager : AbpSuiteDomainService
{
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;
    private readonly DataTypeManager _dataTypeManager;
    private readonly EnumTypeManager _enumTypeManager;

    public ProjectEntityManager(EntityModelManager entityModelManager, ProjectManager projectManager,
        DataTypeManager dataTypeManager, EnumTypeManager enumTypeManager)
    {
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
        _dataTypeManager = dataTypeManager;
        _enumTypeManager = enumTypeManager;
    }

    public async Task<GeneratorProjectTemplateContext> GetProjectContextAsync(Guid projectId)
    {
        var result = new GeneratorProjectTemplateContext();
        var entities = await _entityModelManager.FindByProjectIdAsync(projectId);
        // 获取所有实体
        result.ProjectEntities = ObjectMapper.Map<List<EntityModelDto>, List<GeneratorProjectEntityContext>>(entities);
        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListByProjectIdAsync(projectId);
        result.EntityModels = RecursionEntity(entities, null, dataTypes, enumTypes);
        var project = await _projectManager.GetAsync(projectId);
        result.Projects = ObjectMapper.Map<ProjectDto, GeneratorProjectContext>(project);
        return result;
    }

    /// <summary>
    /// 获取聚合根上下文信息
    /// 包括项目
    /// </summary>
    /// <param name="aggregateId">聚合根id</param>
    public async Task<GeneratorTemplateContext> GetAggregateContextAsync(Guid aggregateId)
    {
        var result = new GeneratorTemplateContext();
        var entity = await _entityModelManager.FindAggregateAsync(aggregateId);

        if (entity == null) throw new UserFriendlyException("聚合根不存在");

        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListAsync(aggregateId);
        var list = RecursionEntity(entity, null, dataTypes, enumTypes);
        result.EntityModel = list.FirstOrDefault();
        var project = await _projectManager.GetAsync(entity.First().ProjectId);
        result.Project = ObjectMapper.Map<ProjectDto, GeneratorProjectContext>(project);
        return result;
    }

    /// <summary>
    /// 获取实体上下文信息
    /// 包括项目，聚合根
    /// </summary>
    /// <param name="entityId">聚合根id</param>
    public async Task<GeneratorTemplateContext> GetEntityContextAsync(Guid entityId)
    {
        var result = new GeneratorTemplateContext();
        var entity = await _entityModelManager.FindAsync(entityId);

        if (entity == null) throw new UserFriendlyException("实体不存在");
        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListAsync(entityId);
        var list = RecursionEntity(new List<EntityModelDto>() { entity }, entity.ParentId, dataTypes, enumTypes);
        result.EntityModel = list.FirstOrDefault();
        var project = await _projectManager.GetAsync(entity.ProjectId);
        result.Project = ObjectMapper.Map<ProjectDto, GeneratorProjectContext>(project);
        return result;
    }

    private List<GeneratorEntityModelContext> RecursionEntity(List<EntityModelDto> entities, Guid? parentId, List<DataTypeDto> dataTypes, List<EnumTypeDto> enumTypes)
    {
        var tree = new List<GeneratorEntityModelContext>();
        var list = entities.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            var child = new GeneratorEntityModelContext()
            {
                Id = detail.Id,
                Code = detail.Code,
                Description = detail.Description,
                RelationalType = detail.RelationalType,
                IsRoot = !detail.ParentId.HasValue
            };
            foreach (var detailEntityModelProperty in detail.EntityModelProperties)
            {
                var property = new GeneratorEntityModelPropertyContext()
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
                        property.EnumType = new GeneratorEnumTypeContext()
                        {
                            Id = currentEnum.Id,
                            Code = currentEnum.Code,
                            Description = currentEnum.Description
                        };
                    }
                }
                else
                {
                    var currentData = dataTypes.FirstOrDefault(e => property.DataTypeId != null && e.Id == property.DataTypeId.Value);
                    if (currentData != null)
                    {
                        property.DataType = new GeneratorDataTypeContext()
                        {
                            Id = currentData.Id,
                            Code = currentData.Code,
                            Description = currentData.Description
                        };
                    }
                }

                child.Properties.Add(property);
            }

            child.EntityModels.AddRange(RecursionEntity(entities, detail.Id, dataTypes, enumTypes));
            tree.Add(child);
        }

        return tree;
    }
}