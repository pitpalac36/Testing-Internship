using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UnitDemo
{
    [TestClass]
    public class TestHomepage: BaseTest
    {

        [TestMethod]
        public void CartSummaryIsShownWhenClickingOnCartLogo()
        {
            IWebElement item = Driver.webDriver.FindElement(By.CssSelector(".skip-link.skip-cart.no-count"));
            item.Click();
            new WebDriverWait(Driver.webDriver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".minicart-wrapper")));
            IWebElement cart_summary = Driver.webDriver.FindElement(By.CssSelector(".minicart-wrapper"));
            //Assert.IsTrue(cart_summary.Displayed);
            cart_summary.Displayed.Should().BeTrue();

        }


        [TestMethod]
        public void CartSummaryIsNotShownWhenOpeningThePage()
        {
            IWebElement cart_summary = Driver.webDriver.FindElement(By.CssSelector(".minicart-wrapper"));
            //Assert.IsFalse(cart_summary.Displayed);
            cart_summary.Displayed.Should().BeFalse();
        }
        [TestMethod]
        public void HoverOverWomenSectionOpensSubMenu()
        {
            IWebElement woman_section = Driver.webDriver.FindElement(By.CssSelector(".level0.nav-1.first.parent"));
            Actions builder = new Actions(Driver.webDriver);
            builder.MoveToElement(woman_section).Perform();
            IList<IWebElement> menu_options = woman_section.FindElements(By.CssSelector("ul > li"));
            //Assert.IsFalse(menu_options.Count == 0);
            menu_options.Should().NotBeEmpty();
        }

        [TestMethod]
        public void ClickOnWomenRedirectsToWomenPage()
        {
            string old_url = Driver.webDriver.Url;
            IWebElement woman_section = Driver.webDriver.FindElement(By.CssSelector(".level0.nav-1.first.parent"));
            woman_section.Click();
            string new_url = Driver.webDriver.Url;
            //Assert.AreNotEqual(new_url, old_url);
            new_url.Should().NotBeEquivalentTo(old_url);
        }
    }
}
