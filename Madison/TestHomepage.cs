using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UnitDemo
{
    [TestClass]
    public class TestHomepage
    {
        public static IWebDriver WebDriver;

        [TestInitialize]
        public void TestInitialize()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            WebDriver.Quit();
        }

        [TestMethod]
        public void CartSummaryIsShownWhenClickingOnCartLogo()
        {
            IWebElement item = WebDriver.FindElement(By.CssSelector(".skip-link.skip-cart.no-count"));
            item.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".minicart-wrapper")));
            IWebElement cart_summary = WebDriver.FindElement(By.CssSelector(".minicart-wrapper"));
            //Assert.IsTrue(cart_summary.Displayed);
            cart_summary.Displayed.Should().BeTrue();

        }


        [TestMethod]
        public void CartSummaryIsNotShownWhenOpeningThePage()
        {
            IWebElement cart_summary = WebDriver.FindElement(By.CssSelector(".minicart-wrapper"));
            //Assert.IsFalse(cart_summary.Displayed);
            cart_summary.Displayed.Should().BeFalse();
        }
        [TestMethod]
        public void HoverOverWomenSectionOpensSubMenu()
        {
            IWebElement woman_section = WebDriver.FindElement(By.CssSelector(".level0.nav-1.first.parent"));
            Actions builder = new Actions(WebDriver);
            builder.MoveToElement(woman_section).Perform();
            IList<IWebElement> menu_options = woman_section.FindElements(By.CssSelector("ul > li"));
            //Assert.IsFalse(menu_options.Count == 0);
            menu_options.Should().NotBeEmpty();
        }

        [TestMethod]
        public void ClickOnWomenRedirectsToWomenPage()
        {
            string old_url = WebDriver.Url;
            IWebElement woman_section = WebDriver.FindElement(By.CssSelector(".level0.nav-1.first.parent"));
            woman_section.Click();
            string new_url = WebDriver.Url;
            //Assert.AreNotEqual(new_url, old_url);
            new_url.Should().NotBeEquivalentTo(old_url);
        }
    }
}
