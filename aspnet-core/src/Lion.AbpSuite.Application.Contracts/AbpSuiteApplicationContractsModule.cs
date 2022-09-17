using Lion.AbpPro.BasicManagement;
using Lion.AbpPro.DataDictionaryManagement;
using Lion.AbpPro.NotificationManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainSharedModule),
        typeof(AbpObjectExtendingModule),
        typeof(BasicManagementApplicationContractsModule),
        typeof(NotificationManagementApplicationContractsModule),
        typeof(DataDictionaryManagementApplicationContractsModule)
    )]
    public class AbpSuiteApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpSuiteDtoExtensions.Configure();
        }
    }
}
