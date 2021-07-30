using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Madison.Helpers
{
    public class BaseTest
    {
 
        [TestInitialize]
        public void Before()
        {
            Driver.webDriver = new ChromeDriver();
            Driver.webDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");
            new WebDriverWait(Driver.webDriver, TimeSpan.FromSeconds(30.0))
                .Until(d => Driver.webDriver.ExecuteJavaScript<string>("return document.readyState").Equals("complete"));
        }

        [TestCleanup]
        public void After()
        {
            Driver.webDriver.Close();
            Driver.webDriver.Quit();
        }
    }
}
