using Madison.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;

namespace Madison.Pages
{
    public class HomePage
    {
        #region Selectors
        private readonly By homeDecorListSelector = By.CssSelector(".level0.nav-4.parent li");
        private readonly By SectionsListSelector = By.CssSelector("#nav ol li.level0");
        private readonly By SectionsSelector = By.CssSelector(".nav-primary");
        private readonly By MainImageHomeDecorSelector = By.CssSelector(".category-image");
        private readonly By homeDecorButtonSelector = By.CssSelector(".level0.nav-4.parent .level0.has-children");
        private readonly By electronicsHomePageSelector = By.CssSelector(".catblocks li:nth-child(3) a img");
        private readonly By electronicsPageTitleSelector = By.CssSelector(".page-title.category-title h1");
        private readonly By accountElement = By.CssSelector(".account-cart-wrapper > a");
        private readonly By menuElements = By.CssSelector("#header-account>.links>ul li");
        private readonly By _cartQuantityLabel = By.CssSelector(".count");
        private readonly By _cartSelector = By.Id("header-cart");
        private readonly By _viewMyCartSelector = By.ClassName("top-link-cart");

        
        // second flow
        private readonly By menSectionSelector = By.CssSelector(".level0.nav-2.parent .level0.has-children");
        private readonly By menNewArrivalsSelector = By.CssSelector(".col-main li:nth-child(1) img");

        #endregion


        /// <summary>
        /// Methods which click on elements
        /// </summary>
        public void goToHomeDecor()
        {
            homeDecorButtonSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsCartQuantityLabelPresent()
        {
            return _cartQuantityLabel.IsElementPresent();
        }


        public void goFromHomePageToElectronics()
        {
            electronicsHomePageSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();

        }

        public void goToMenSection() 
        {
            menSectionSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void goToMenNewArrivals() 
        {
            menNewArrivalsSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }


        /// <summary>
        /// Methods which extract Lists
        /// </summary>
        /// <returns></returns>

        public IReadOnlyCollection<IWebElement> getSectionsList()
        {
            var elems = SectionsListSelector.GetElements();
            return elems;
        }

        /// <summary>
        /// Methods which check visibility of an element on the page
        /// </summary>
        /// <returns></returns>
        public bool checkIfProductSectionsIsVisible() {
            var elems = SectionsSelector.IsElementPresent();
            return elems;
        }

        public bool checkIfHomeDecorDropdownIsVisible() {
            var elems = homeDecorListSelector.IsElementPresent();
            return elems;
        }
        public bool checkIfHomeMainImageIsVisible() {
            var elem =  MainImageHomeDecorSelector.IsElementPresent();
            return elem;
        }
        public bool checkIfPageTitleIsVisible() {
            var elem = electronicsPageTitleSelector.IsElementPresent();
            return elem;
        }

        //
        public void ClickOnAccount()
        {
            accountElement.ActionClick();
        }

        public void ClickOnCart()
        {
            _cartSelector.ActionClick();
        }

        public void GoToCart()
        {
            _viewMyCartSelector.ActionClick();
        }

        public void SelectMyAccountMenu(string accountMenu)
        {
            ClickOnAccount();
            menuElements.GetElements().First(item => item.Text == accountMenu).Click();
        }
    }
}
