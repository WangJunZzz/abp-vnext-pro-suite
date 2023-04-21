
using Lion.AbpSuite.Localization;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementHttpApiModule),
        typeof(NotificationManagementHttpApiModule)
        )]
    public class AbpSuiteHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpSuiteResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
