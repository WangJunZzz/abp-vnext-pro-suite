namespace Lion.AbpSuite.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpSuiteEntityFrameworkCoreModule),
        typeof(AbpSuiteApplicationContractsModule)
        )]
    public class AbpSuiteDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
