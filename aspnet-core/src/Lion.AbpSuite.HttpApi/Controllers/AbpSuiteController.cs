namespace Lion.AbpSuite.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpSuiteController : AbpController
    {
        protected AbpSuiteController()
        {
            LocalizationResource = typeof(AbpSuiteResource);
        }
    }
}