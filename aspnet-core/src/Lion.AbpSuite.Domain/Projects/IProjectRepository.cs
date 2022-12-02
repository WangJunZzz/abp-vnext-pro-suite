namespace Lion.AbpSuite.Projects;

public interface IProjectRepository : IBasicRepository<Project, Guid>
{
    Task<Project> FindAsync(string name);
    /// <summary>
    /// 根据名称查询模板，但是排除指定id的模板
    /// </summary>
    Task<Project> FindByNameExcludeIdAsync(string name,Guid id, bool includeDetail = true);
    
    Task<List<Project>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true);

    Task<long> GetCountAsync(string filter = null);
}