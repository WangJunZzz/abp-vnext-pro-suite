namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainModule),
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementApplicationModule),
        typeof(NotificationManagementApplicationModule)
        )]
    public class AbpSuiteApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpSuiteApplicationModule>();
            });
            
        }
    }
}
