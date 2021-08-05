using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using DriverOptions = NsTestFrameworkUI.Helpers.DriverOptions;

[assembly: Parallelize(Workers = 8, Scope = ExecutionScope.MethodLevel)]
namespace Madison.Helpers
{
    public class BaseTest
    {
 
        [TestInitialize]
        public void Before()
        {
            Browser.InitializeDriver(new DriverOptions
            {
                IsHeadless = false
            });
            Browser.GoTo(WebLinks.Homepage);
        }

        [TestCleanup]
        public void After()
        {
            Browser.Cleanup();
        }
    }
}
