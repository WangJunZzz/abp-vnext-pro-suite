namespace Lion.AbpSuite.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IAbpSuiteDbContext : IEfCoreDbContext
    {
        DbSet<Template> Templates { get; set; }
    }
}
