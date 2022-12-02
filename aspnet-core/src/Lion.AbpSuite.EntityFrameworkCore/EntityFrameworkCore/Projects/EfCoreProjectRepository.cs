using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Aggregates;

namespace Lion.AbpSuite.EntityFrameworkCore.Projects;

public class EfCoreProjectRepository :
    EfCoreRepository<IAbpSuiteDbContext, Project, Guid>,
    IProjectRepository
{
    public EfCoreProjectRepository(IDbContextProvider<IAbpSuiteDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Project> FindAsync(string name)
    {
        return await (await GetDbSetAsync())
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<Project> FindByNameExcludeIdAsync(string name, Guid id, bool includeDetail = true)
    {
        return await (await GetDbSetAsync())
            .FirstOrDefaultAsync(t => t.Name == name && t.Id != id);
    }

    public async Task<List<Project>> GetListAsync(string filter = null, int maxResultCount = 10, int skipCount = 0, bool includeDetails = true)
    {
        return await (await GetDbSetAsync())
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
}