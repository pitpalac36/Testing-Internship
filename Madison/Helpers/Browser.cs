using NsTestFrameworkUI.Helpers;

namespace Madison.Helpers
{
    public static class BrowserHelper
    {
        public static string GetCurrentUrl()
        {
            return Browser.WebDriver.Url;
        }
    }
}
