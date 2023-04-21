namespace Lion.AbpSuite.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSuiteTestBaseModule),
        typeof(AbpSuiteEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
        )]
    public class AbpSuiteEntityFrameworkCoreTestModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureInMemorySqlite(context.Services);
        }

        private void ConfigureInMemorySqlite(IServiceCollection services)
        {
            _sqliteConnection = CreateDatabaseAndGetConnection();

            services.Configure<AbpDbContextOptions>(options =>
            {
              
                options.Configure(context =>
                {
                    context.DbContextOptions.UseSqlite(_sqliteConnection);
                });
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Dispose();
        }

        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<AbpSuiteDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new AbpSuiteDbContext(options))
            {
                context.GetService<IRelationalDatabaseCreator>().CreateTables();
            }

            return connection;
        }
    }
}
