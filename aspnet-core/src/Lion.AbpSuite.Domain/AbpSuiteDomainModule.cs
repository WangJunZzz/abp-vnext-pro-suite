namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainSharedModule),
        typeof(BasicManagementDomainModule),
        typeof(NotificationManagementDomainModule)
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