using Lion.AbpPro.DataDictionaryManagement;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteApplicationContractsModule),
        typeof(BasicManagementHttpApiModule),
        typeof(NotificationManagementHttpApiModule),
        typeof(DataDictionaryManagementHttpApiModule)
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
