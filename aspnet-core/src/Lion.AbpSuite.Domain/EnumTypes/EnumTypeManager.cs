namespace Lion.AbpSuite.EnumTypes;

public class EnumTypeManager : AbpSuiteDomainService
{
    private readonly IEnumTypeRepository _enumTypeRepository;

    public EnumTypeManager(IEnumTypeRepository enumTypeRepository)
    {
        _enumTypeRepository = enumTypeRepository;
    }

    public async Task<List<EnumTypeDto>> ListAsync(Guid entityModelId, string filter = null)
    {
        var list = await _enumTypeRepository.ListAsync(entityModelId, filter);
        return ObjectMapper.Map<List<EnumType>, List<EnumTypeDto>>(list);
    }
    public async Task<List<EnumTypeDto>> ListByProjectIdAsync(Guid projectId, string filter = null)
    {
        var list = await _enumTypeRepository.ListByProjectIdAsync(projectId, filter);
        return ObjectMapper.Map<List<EnumType>, List<EnumTypeDto>>(list);
    }
    public async Task<EnumTypeDto> FindAsync(Guid id)
    {
        var entity = await _enumTypeRepository.FindAsync(id);
        return ObjectMapper.Map<EnumType, EnumTypeDto>(entity);
    }

    public async Task<EnumTypeDto> CreateAsync(string code, string description, Guid entityModelId,Guid projectId)
    {
        var entity = await _enumTypeRepository.FindAsync(code,entityModelId);
        if (entity != null)
        {
            throw new UserFriendlyException("枚举已存在");
        }

        entity = new EnumType(GuidGenerator.Create(), code, description, entityModelId, projectId,CurrentTenant.Id);
        await _enumTypeRepository.InsertAsync(entity);
        return ObjectMapper.Map<EnumType, EnumTypeDto>(entity);
    }

    public async Task<EnumTypeDto> UpdateAsync(Guid enumTypeId, string code, string description)
    {
        var entity = await _enumTypeRepository.FindByCodeExcludeIdAsync(code, enumTypeId);
        if (entity != null)
        {
            throw new UserFriendlyException("枚举已存在");
        }

        entity = await _enumTypeRepository.FindAsync(enumTypeId);
        if (entity == null)
        {
            throw new UserFriendlyException("枚举不存在");
        }

        entity.Update(code, description);
        await _enumTypeRepository.UpdateAsync(entity);
        return ObjectMapper.Map<EnumType, EnumTypeDto>(entity);
    }

    public async Task DeleteAsync(Guid enumTypeId)
    {
        var entity = await _enumTypeRepository.FindAsync(enumTypeId);
        if (entity == null)
        {
            throw new UserFriendlyException("枚举不存在");
        }

        await _enumTypeRepository.DeleteAsync(entity);
    }


    public async Task CreatePropertyAsync(string code, int value, string description, Guid enumTypeId)
    {
        var entity = await _enumTypeRepository.FindAsync(enumTypeId);
        if (entity == null)
        {
            throw new UserFriendlyException("枚举不存在");
        }

        entity.AddPropery(GuidGenerator.Create(), code, value, description);
        await _enumTypeRepository.UpdateAsync(entity);
    }

    public async Task UpdatePropertyAsync(Guid id, string code, int value, string description, Guid enumTypeId)
    {
        var entity = await _enumTypeRepository.FindAsync(enumTypeId);
        if (entity == null)
        {
            throw new UserFriendlyException("枚举不存在");
        }

        entity.UpdatePropery(id, code, value, description);
        await _enumTypeRepository.UpdateAsync(entity);
    }

    public async Task DeletePropertyAsync(Guid enumTypeId, Guid propertyId)
    {
        var entity = await _enumTypeRepository.FindAsync(enumTypeId);
        if (entity == null)
        {
            throw new UserFriendlyException("枚举不存在");
        }

        entity.DeletePropery(propertyId);
        await _enumTypeRepository.UpdateAsync(entity);
    }

}