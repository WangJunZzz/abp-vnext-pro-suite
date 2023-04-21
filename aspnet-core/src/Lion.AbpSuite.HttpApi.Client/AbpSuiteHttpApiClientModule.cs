using Lion.AbpPro.BasicManagement;
using Lion.AbpPro.NotificationManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementHttpApiClientModule),
        typeof(NotificationManagementHttpApiClientModule)
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
