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
        private readonly By SectionsListSelector = By.CssSelector("# nav ol li.level0");


        #endregion

        public void openHomeDecor()
        {
            Driver.webDriver.FindElement(homeDecorSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();


        }

        public void clickOnElectronics()
        {
            Driver.webDriver.FindElement(electronicsSelector).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }

        public IReadOnlyCollection<IWebElement> getHomeDecorList() {
            var list = Driver.webDriver.FindElements(homeDecorListSelector);
            return list;
        }
    }
}
