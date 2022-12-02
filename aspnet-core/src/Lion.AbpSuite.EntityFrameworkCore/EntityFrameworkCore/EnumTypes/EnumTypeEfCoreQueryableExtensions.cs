using Lion.AbpSuite.EnumTypes.Aggregates;

namespace Lion.AbpSuite.EntityFrameworkCore.EnumTypes;

public static class EnumTypeEfCoreQueryableExtensions
{
    public static IQueryable<EnumType> IncludeDetails(this IQueryable<EnumType> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.EnumTypeProperties);
    }
}