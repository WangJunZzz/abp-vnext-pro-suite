namespace Lion.AbpSuite.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpSuiteDbSchemaMigrator
        : IAbpSuiteDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpSuiteDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpSuiteMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpSuiteDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}