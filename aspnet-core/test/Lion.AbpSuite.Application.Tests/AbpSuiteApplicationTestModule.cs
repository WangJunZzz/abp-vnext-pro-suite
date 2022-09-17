using Volo.Abp.Modularity;

namespace Lion.AbpSuite
{
    [DependsOn(
        typeof(AbpSuiteApplicationModule),
        typeof(AbpSuiteDomainTestModule)
        )]
    public class AbpSuiteApplicationTestModule : AbpModule
    {

    }
}