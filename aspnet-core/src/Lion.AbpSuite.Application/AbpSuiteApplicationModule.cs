using Lion.AbpPro.DataDictionaryManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainModule),
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementApplicationModule),
        typeof(NotificationManagementApplicationModule),
        typeof(DataDictionaryManagementApplicationModule),
        typeof(AbpSuiteFreeSqlModule)
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
