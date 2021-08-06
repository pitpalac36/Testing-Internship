using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using DriverOptions = NsTestFrameworkUI.Helpers.DriverOptions;

namespace Madison.Helpers
{
    public class MagentoTest
    {

        [TestInitialize]
        public void Before()
        {
            Browser.InitializeDriver(new DriverOptions
            {
                IsHeadless = false
            });
            Browser.GoTo(WebLinks.MagentoLogin);
        }

        [TestCleanup]
        public void After()
        {
            Browser.Cleanup();
        }
    }
}
