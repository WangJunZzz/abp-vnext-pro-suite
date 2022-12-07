namespace Lion.AbpSuite.EntityModels;

public class EntityModelManager : AbpSuiteDomainService
{
    private readonly IEntityModelRepository _entityModelRepository;

    public EntityModelManager(IEntityModelRepository entityModelRepository)
    {
        _entityModelRepository = entityModelRepository;
    }

    public async Task<EntityModelDto> FindAsync(Guid id)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task<EntityModelDto> GetAsync(Guid id)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null) throw new UserFriendlyException("实体不存在");
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task<List<EntityModelDto>> FindAggregateAsync(Guid id)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        var items = await _entityModelRepository.FindByParentIdAsync(id);
        var itemDto = ObjectMapper.Map<List<EntityModel>, List<EntityModelDto>>(items);
        var entityDto = ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
        itemDto.Add(entityDto);
        return itemDto;
    }

    public async Task<List<EntityModelDto>> ListAsync(Guid projectId)
    {
        var list = await _entityModelRepository.ListAsync(projectId);
        return ObjectMapper.Map<List<EntityModel>, List<EntityModelDto>>(list);
    }

    /// <summary>
    /// 创建聚合根
    /// </summary>
    public async Task<EntityModelDto> CreateAggregateAsync(Guid projectId, string code, string description)
    {
        if (code.IsNullOrWhiteSpace())
        {
            throw new UserFriendlyException("Code不能为空");
        }

        if (description.IsNullOrWhiteSpace())
        {
            throw new UserFriendlyException("描述不能为空");
        }

        var entity = await _entityModelRepository.FindAsync(projectId, code);
        if (entity != null)
        {
            throw new UserFriendlyException("聚合根已经存在");
        }

        var id = GuidGenerator.Create();
        entity = new EntityModel(id, projectId, code, description, id, tenantId: CurrentTenant.Id);

        await _entityModelRepository.InsertAsync(entity);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    /// <summary>
    /// 创建聚合根下实体
    /// </summary>
    public async Task<EntityModelDto> CreateEntityAsync(
        Guid parentId,
        string code,
        string description,
        RelationalType relationalType)
    {
        if (code.IsNullOrWhiteSpace())
        {
            throw new UserFriendlyException("Code不能为空");
        }

        if (description.IsNullOrWhiteSpace())
        {
            throw new UserFriendlyException("描述不能为空");
        }

        var entity = await _entityModelRepository.FindAsync(parentId);
        if (entity == null)
        {
            throw new UserFriendlyException("聚合根不存在");
        }

        var detail = await _entityModelRepository.FindAsync(parentId, entity.ProjectId, code);
        if (detail != null)
        {
            throw new UserFriendlyException("实体已存在");
        }

        detail = new EntityModel(GuidGenerator.Create(), entity.ProjectId, code, description, entity.AggregateId, relationalType, entity.Id, entity.TenantId);

        await _entityModelRepository.InsertAsync(detail);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(detail);
    }

    public async Task<EntityModelDto> UpdateAggregateAsync(Guid id, string code, string description)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("聚合根不存在");
        }

        entity.Update(code, description);
        await _entityModelRepository.UpdateAsync(entity);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task<EntityModelDto> UpdateEntityAsync(Guid id, string code, string description, RelationalType relationalType)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("实体不存在");
        }

        entity.Update(code, description, relationalType);
        await _entityModelRepository.UpdateAsync(entity);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task DeleteAggregateAsync(Guid id)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("实体不存在");
        }

        var details = await _entityModelRepository.FindByParentIdAsync(entity.Id);
        if (details.Count > 0)
        {
            await _entityModelRepository.DeleteManyAsync(details);
        }

        await _entityModelRepository.DeleteAsync(entity);
    }

    public async Task DeleteEntityAsync(Guid aggregateId, Guid id)
    {
        var entity = await _entityModelRepository.FindAsync(aggregateId);
        if (entity == null)
        {
            throw new UserFriendlyException("聚合根不存在");
        }

        var details = await _entityModelRepository.FindAsync(id);
        if (details != null)
        {
            await _entityModelRepository.DeleteAsync(details);
        }

        await _entityModelRepository.UpdateAsync(entity);
    }

    public async Task<EntityModelDto> CreatePropertyAsync(Guid id,
        string code,
        string description,
        bool isRequired = false,
        int? maxLength = null,
        int? minLength = null,
        int? decimalPrecision = null,
        int? decimalScale = null,
        Guid? enumTypeId = null,
        Guid? dataTypeId = null
    )
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("实体不存在");
        }


        if (!enumTypeId.HasValue && !dataTypeId.HasValue)
        {
            throw new UserFriendlyException("实体数据类型不能为空");
        }

        if (enumTypeId.HasValue)
        {
            dataTypeId = null;
        }

        entity.AddProperty(GuidGenerator.Create(), code, description, isRequired, maxLength, minLength, decimalPrecision, decimalScale, enumTypeId,
            dataTypeId);
        await _entityModelRepository.UpdateAsync(entity);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task<EntityModelDto> UpdatePropertyAsync(Guid id,
        Guid propertyId,
        string code,
        string description,
        bool isRequired = false,
        int? maxLength = null,
        int? minLength = null,
        int? decimalPrecision = null,
        int? decimalScale = null,
        Guid? enumTypeId = null,
        Guid? dataTypeId = null
    )
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("实体不存在");
        }

        if (!enumTypeId.HasValue && !dataTypeId.HasValue)
        {
            throw new UserFriendlyException("实体数据类型不能为空");
        }

        if (enumTypeId.HasValue)
        {
            dataTypeId = null;
        }

        entity.UpdateProperty(propertyId, code, description, isRequired, maxLength, minLength, decimalPrecision, decimalScale, enumTypeId,
            dataTypeId);
        await _entityModelRepository.UpdateAsync(entity);
        return ObjectMapper.Map<EntityModel, EntityModelDto>(entity);
    }

    public async Task DeletePropertyAsync(Guid id, Guid propertyId)
    {
        var entity = await _entityModelRepository.FindAsync(id);
        if (entity == null)
        {
            throw new UserFriendlyException("实体不存在");
        }

        entity.DeleteProperty(propertyId);
        await _entityModelRepository.UpdateAsync(entity);
    }

    public async Task<List<EntityModelDto>> FindByProjectIdAsync(Guid projectId)
    {
        var entities = await _entityModelRepository.FindByProjectIdAsync(projectId);
        return ObjectMapper.Map<List<EntityModel>, List<EntityModelDto>>(entities);
    }
}