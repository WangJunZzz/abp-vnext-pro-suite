using System.Linq.Expressions;
using Lion.AbpSuite.EntityModels;
using Lion.AbpSuite.EntityModels.Aggregates;

namespace Lion.AbpSuite.EntityFrameworkCore.EntityModels
{
    /// <summary>
    /// 实体 仓储Ef core 实现
    /// </summary>
    public class EfCoreEntityModelRepository :
        EfCoreRepository<IAbpSuiteDbContext, EntityModel, Guid>,
        IEntityModelRepository
    {
        public EfCoreEntityModelRepository(IDbContextProvider<IAbpSuiteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<EntityModel>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }

        public async Task<EntityModel> FindAsync(Guid projectId, string code, bool includeDetail = true)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetail)
                .FirstOrDefaultAsync(t => t.ProjectId == projectId && t.Code == code);
        }

        public async Task<EntityModel> FindAsync(Guid parentId, Guid projectId, string code, bool includeDetail = true)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetail)
                .FirstOrDefaultAsync(t => t.ParentId == parentId && t.ProjectId == projectId && t.Code == code);
        }

        public async Task<List<EntityModel>> FindByParentIdAsync(Guid parentId, bool includeDetail = true)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetail)
                .Where(e => e.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<List<EntityModel>> FindByProjectIdAsync(Guid projectId, bool includeDetail = true)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetail)
                .Where(e => e.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<EntityModel>> ListAsync(Guid projectId, bool includeDetail = true)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetail)
                .Where(e => e.ProjectId == projectId)
                .ToListAsync();
        }
    }
}