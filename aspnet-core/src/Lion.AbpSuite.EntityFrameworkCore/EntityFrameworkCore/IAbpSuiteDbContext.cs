using Lion.AbpSuite.EntityModels.Aggregates;
using Lion.AbpSuite.EnumTypes.Aggregates;
using Lion.AbpSuite.Projects.Aggregates;

namespace Lion.AbpSuite.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IAbpSuiteDbContext : IEfCoreDbContext
    {
        DbSet<Template> Templates { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<EntityModel> EntityModels { get; set; }
        DbSet<DataType> DataTypes { get; set; }
        DbSet<EnumType> EnumTypes { get; set; }
    }
}