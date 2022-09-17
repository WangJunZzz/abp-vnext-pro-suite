using Lion.AbpSuite.FreeSqlReppsitory.Tests;
using Lion.AbpSuite.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.AbpSuite
{
    public abstract class AbpSuiteFreeSqlRepositoryTestBase: AbpSuiteTestBase<AbpSuiteFreeSqlRepositoryTestModule>
    {
        public AbpSuiteFreeSqlRepositoryTestBase()
        {
            ServiceProvider.InitializeLocalization();
        }
    }
}
