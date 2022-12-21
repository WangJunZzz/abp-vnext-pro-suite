namespace Lion.AbpSuite.EnumTypes;

public interface IEnumTypeRepository : IBasicRepository<EnumType, Guid>
{
    Task<List<EnumType>> ListAsync(Guid entityModelId, string filter = null, bool includeDetail = true);
    
    Task<List<EnumType>> ListByProjectIdAsync(Guid projectId, string filter = null, bool includeDetail = true);

    Task<EnumType> FindAsync(string code, bool includeDetail = true);

    Task<EnumType> FindAsync(string code, Guid entityModelId, bool includeDetail = true);

    Task<EnumType> FindByCodeExcludeIdAsync(string code, Guid id, bool includeDetail = true);
}