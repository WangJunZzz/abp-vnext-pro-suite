namespace Lion.AbpSuite.EntityFrameworkCore.Templates;

/// <summary>
/// 模板 仓储Ef core 实现
/// </summary>
public class EfCoreTemplateRepository :
    EfCoreRepository<IAbpSuiteDbContext, Template, Guid>,
    ITemplateRepository
{
    public EfCoreTemplateRepository(IDbContextProvider<IAbpSuiteDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Template> FindByNameAsync(string name, bool includeDetail = true)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetail)
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<Template> FindByNameExcludeIdAsync(string name, Guid id, bool includeDetail = true)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetail)
            .FirstOrDefaultAsync(t => t.Name == name && t.Id != id);
    }

    public async Task<List<Template>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(), e => (e.Name.Contains(filter)))
            .OrderByDescending(e => e.CreationTime)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync();
    }

    public async Task<long> GetCountAsync(string filter = null)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(), e => (e.Name.Contains(filter)))
            .CountAsync();
    }
    
    public override async Task<IQueryable<Template>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}