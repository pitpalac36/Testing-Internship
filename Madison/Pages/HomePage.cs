using Madison.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class HomePage
    {
        #region Selectors
        private readonly By homeDecorSelector = By.CssSelector(".level1.nav-4-3 a");
        private readonly By homeDecorListSelector = By.CssSelector(".level0.nav-4.parent li");
        private readonly By SectionsListSelector = By.CssSelector("#nav ol li.level0");
        private readonly By SectionsSelector = By.CssSelector(".nav-primary");
        private readonly By MainImageHomeDecorSelector = By.CssSelector(".category-image");
        private readonly By homeDecorButtonSelector = By.CssSelector(".level0.nav-4.parent .level0.has-children");
        private readonly By electronicsHomePageSelector = By.CssSelector(".catblocks li:nth-child(3) a img");
        private readonly By electronicsPageTitleSelector = By.CssSelector(".page-title.category-title h1");

        #endregion

        /// <summary>
        /// Methods which click on elements
        /// </summary>
        public void goToHomeDecor()
        {
            Driver.webDriver.FindElement(homeDecorButtonSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }

        public void goFromHomePageToElectronics()
        {
            Driver.webDriver.FindElement(electronicsHomePageSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }
        /// <summary>
        /// Methods which extract Lists
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<IWebElement> getHomeDecorList() {
            var elems = Driver.webDriver.FindElements(homeDecorListSelector);
            WaitHelpers.WaitUntilDocumentReady();
            return elems;
        }

        public IReadOnlyCollection<IWebElement> getSectionsList()
        {
           var elems = Driver.webDriver.FindElements(SectionsListSelector);
            WaitHelpers.WaitUntilDocumentReady();
            return elems;
        }

        /// <summary>
        /// Methods which check visibility of an element on the page
        /// </summary>
        /// <returns></returns>
        public bool checkIfProductSectionsIsVisible() {
            var elems = Driver.webDriver.FindElement(SectionsSelector).Displayed;
            WaitHelpers.WaitUntilDocumentReady();
            return elems;
        }

        public bool checkIfHomeDecorDropdownIsVisible() {
            var elems = Driver.webDriver.FindElement(homeDecorListSelector).Displayed;
            WaitHelpers.WaitUntilDocumentReady();
            return elems;
        }
        public bool checkIfHomeMainImageIsVisible() {
            var elem =  Driver.webDriver.FindElement(MainImageHomeDecorSelector).Displayed;
            WaitHelpers.WaitUntilDocumentReady();
            return elem;
        }
        public bool checkIfPageTitleIsVisible() {
            var elem = Driver.webDriver.FindElement(electronicsPageTitleSelector).Displayed;
            WaitHelpers.WaitUntilDocumentReady();
            return elem;
        }
        

        #region Selectors

         private readonly By accountElement = By.CssSelector(".account-cart-wrapper > a");
         private readonly By menuElements = By.CssSelector("#header-account>.links>ul li");
        #endregion

        public void ClickOnAccount()
        {
            Driver.webDriver.FindElement(accountElement).Click();
        }

        private void SelectMyAccountMenu(string accountMenu)
        {
            Driver.webDriver.FindElements(menuElements).First(item => item.Text == accountMenu).Click();
        }

        public void ClickLogInButton()
        {
            SelectMyAccountMenu("Log In");
           
        }
    }
}
