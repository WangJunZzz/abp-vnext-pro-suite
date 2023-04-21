using Lion.AbpPro.BasicManagement;
using Lion.AbpPro.BasicManagement.Localization;
using Lion.AbpPro.Core;
using Lion.AbpPro.NotificationManagement;
using Lion.AbpSuite.Localization;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(BasicManagementDomainSharedModule),
        typeof(NotificationManagementDomainSharedModule),
        typeof(LionAbpProCoreModule)
    )]
    public class AbpSuiteDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpSuiteGlobalFeatureConfigurator.Configure();
            AbpSuiteModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSuiteDomainSharedModule>(AbpSuiteDomainSharedConsts.NameSpace);
            });
          
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpSuiteResource>(AbpSuiteDomainSharedConsts.DefaultCultureName)
                    .AddVirtualJson("/Localization/AbpSuite")
                    .AddBaseTypes(typeof(BasicManagementResource))
                    .AddBaseTypes(typeof(AbpTimingResource));

                options.DefaultResourceType = typeof(AbpSuiteResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace(AbpSuiteDomainSharedConsts.NameSpace, typeof(AbpSuiteResource));
            });
        }

       
    }
}