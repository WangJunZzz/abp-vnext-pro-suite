using Lion.AbpPro.BasicManagement;
using Lion.AbpPro.DataDictionaryManagement;
using Lion.AbpPro.NotificationManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainSharedModule),
        typeof(BasicManagementDomainModule),
        typeof(NotificationManagementDomainModule),
        typeof(DataDictionaryManagementDomainModule)
    )]
    public class AbpSuiteDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<AbpSuiteDomainModule>(); });
            Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<AbpSuiteDomainModule>(); });
        }
    }
}