namespace Lion.AbpSuite
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpSuiteAppService : ApplicationService
    {
        protected AbpSuiteAppService()
        {
            LocalizationResource = typeof(AbpSuiteResource);
        }
    }
}
