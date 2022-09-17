namespace Lion.AbpSuite.Templates;

public interface ITemplateRepository : IBasicRepository<Template, Guid>
{
    Task<Template> FindByNameAsync(string name, bool includeDetail = true);
    
    /// <summary>
    /// 根据名称查询模板，但是排除指定id的模板
    /// </summary>
    Task<Template> FindByNameExcludeIdAsync(string name,Guid id, bool includeDetail = true);

    Task<List<Template>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true);

    Task<long> GetCountAsync(string filter = null);
}