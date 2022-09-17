namespace Lion.AbpSuite.EntityFrameworkCore.Templates;

public static class TemplateEfCoreQueryableExtensions
{
    public static IQueryable<Template> IncludeDetails(this IQueryable<Template> queryable,
        bool include = true)
    {
        return !include ? queryable : queryable.Include(x => x.TemplateDetails);
    }
}