using Lion.AbpSuite.Localization;

namespace Lion.AbpSuite.Permissions
{
    public class AbpSuitePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
           

       
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpSuiteResource>(name);
        }
    }
}