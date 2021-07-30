using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Madison.Helpers
{
    public class BaseTest
    {
        public static IWebDriver driver;

        [TestInitialize]
        public void Before()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");
        }

        [TestCleanup]
        public void After()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
