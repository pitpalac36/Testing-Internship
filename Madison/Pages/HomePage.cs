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
        private readonly By electronicsSelector = By.CssSelector(".level1.nav-4-3");
        private readonly By homeDecorListSelector = By.CssSelector(".level0.nav-4.parent li");
        private readonly By SectionsListSelector = By.CssSelector("#nav ol li.level0");
        private readonly By SectionsSelector = By.CssSelector(".nav-primary");
        private readonly By MainImageHomeDecorSelector = By.CssSelector(".category-image");
        private readonly By homeDecorButtonSelector = By.CssSelector(".level0.nav-4.parent .level0.has-children");

        

        #endregion

        public void goToHomeDecor()
        {
            Driver.webDriver.FindElement(homeDecorButtonSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }

        public void clickOnElectronics()
        {
            Driver.webDriver.FindElement(electronicsSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }

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
    }
}
