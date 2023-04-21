using Lion.AbpPro.BasicManagement.EntityFrameworkCore;
using Lion.AbpPro.NotificationManagement.EntityFrameworkCore;

namespace Lion.AbpSuite.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSuiteDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(BasicManagementEntityFrameworkCoreModule),
        typeof(NotificationManagementEntityFrameworkCoreModule)
    )]
    public class AbpSuiteEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpSuiteEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpSuiteDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also AbpSuiteMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}