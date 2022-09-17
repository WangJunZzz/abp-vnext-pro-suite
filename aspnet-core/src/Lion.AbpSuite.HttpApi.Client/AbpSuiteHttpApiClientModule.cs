using Lion.AbpPro.BasicManagement;
using Lion.AbpPro.DataDictionaryManagement;
using Lion.AbpPro.NotificationManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementHttpApiClientModule),
        typeof(NotificationManagementHttpApiClientModule),
        typeof(DataDictionaryManagementHttpApiClientModule)
    )]
    public class AbpSuiteHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpSuiteApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
