using Lion.AbpSuite.Localization;
using Microsoft.AspNetCore.Authorization;

namespace Lion.AbpSuite.Controllers
{
    /* Inherit your controllers from this class.
     */
    [Authorize]
    public abstract class AbpSuiteController : AbpController
    {
        protected AbpSuiteController()
        {
            LocalizationResource = typeof(AbpSuiteResource);
        }
    }
}