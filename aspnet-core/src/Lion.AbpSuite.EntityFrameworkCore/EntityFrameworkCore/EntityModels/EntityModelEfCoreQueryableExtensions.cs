using Lion.AbpSuite.EntityModels.Aggregates;

namespace Lion.AbpSuite.EntityFrameworkCore.EntityModels;

public static class EntityModelEfCoreQueryableExtensions
{
    public static IQueryable<EntityModel> IncludeDetails(this IQueryable<EntityModel> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.EntityModelProperties);
    }
}