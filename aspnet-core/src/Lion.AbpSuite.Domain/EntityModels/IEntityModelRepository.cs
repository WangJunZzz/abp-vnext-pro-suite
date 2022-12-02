namespace Lion.AbpSuite.EntityModels;

/// <summary>
/// 实体 仓储接口
/// </summary>
public interface IEntityModelRepository : IBasicRepository<EntityModel, Guid>
{
    Task<EntityModel> FindAsync(Guid projectId, string code, bool includeDetail = true);

    Task<EntityModel> FindAsync(Guid id, Guid projectId, string code, bool includeDetail = true);
        
    Task<List<EntityModel>> FindByParentIdAsync(Guid parentId, bool includeDetail = true);
        
    Task<List<EntityModel>> FindByProjectIdAsync(Guid projectId, bool includeDetail = true);
        
    Task<List<EntityModel>> ListAsync(Guid projectId,bool includeDetail = true);
}