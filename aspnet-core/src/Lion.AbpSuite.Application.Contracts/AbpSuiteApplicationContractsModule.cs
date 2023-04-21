namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteDomainSharedModule),
        typeof(AbpObjectExtendingModule),
        typeof(BasicManagementApplicationContractsModule),
        typeof(NotificationManagementApplicationContractsModule)
    )]
    public class AbpSuiteApplicationContractsModule : AbpModule
    {
    }
}