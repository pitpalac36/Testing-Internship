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
        private readonly By _homeDecorListSelector = By.CssSelector(".level0.nav-4.parent li");
        private readonly By _sectionsListSelector = By.CssSelector("#nav ol li.level0 > a");
        private readonly By _sectionsSelector = By.CssSelector(".nav-primary");
        private readonly By _mainImageHomeDecorSelector = By.CssSelector(".category-image");
        private readonly By _homeDecorButtonSelector = By.CssSelector(".level0.nav-4.parent .level0.has-children");
        private readonly By _electronicsHomePageSelector = By.CssSelector(".catblocks li:nth-child(3) a img");
        private readonly By _electronicsPageTitleSelector = By.CssSelector(".page-title.category-title h1");
        private readonly By _accountElement = By.CssSelector(".account-cart-wrapper > a");
        private readonly By _menuElements = By.CssSelector("#header-account>.links>ul li");
        private readonly By _cartQuantityLabel = By.CssSelector(".count");
        private readonly By _cartSelector = By.Id("header-cart");
        private readonly By _viewMyCartSelector = By.ClassName("top-link-cart");

        
        // second flow
        private readonly By _sectionSelector = By.CssSelector(".level0.nav-2.parent > a");
        private readonly By _subsectionSelector = By.CssSelector(".catblocks li a");

        #endregion


        /// <summary>
        /// Methods which click on elements
        /// </summary>
        public void GoToHomeDecor()
        {
            _homeDecorButtonSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsCartQuantityLabelPresent()
        {
            return _cartQuantityLabel.IsElementPresent();
        }


        public void GoFromHomePageToElectronics()
        {
            _electronicsHomePageSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();

        }

        public void GoToMenSection()
        {
            _sectionSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        /// <summary>
        /// Methods which extract Lists
        /// </summary>
        /// <returns></returns>

        public IReadOnlyCollection<IWebElement> GetSectionsList()
        {
            var elems = _sectionsListSelector.GetElements();
            return elems;
        }

        /// <summary>
        /// Methods which check visibility of an element on the page
        /// </summary>
        /// <returns></returns>
        public bool CheckIfProductSectionsIsVisible() {
            var elems = _sectionsSelector.IsElementPresent();
            return elems;
        }

        public bool CheckIfHomeDecorDropdownIsVisible() {
            var elems = _homeDecorListSelector.IsElementPresent();
            return elems;
        }
        public bool CheckIfHomeMainImageIsVisible() {
            var elem =  _mainImageHomeDecorSelector.IsElementPresent();
            return elem;
        }
        public bool CheckIfPageTitleIsVisible() {
            var elem = _electronicsPageTitleSelector.IsElementPresent();
            return elem;
        }

        //
        public void ClickOnAccount()
        {
            _accountElement.ActionClick();
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
            _menuElements.GetElements().First(item => item.Text == accountMenu).Click();
        }

        public void SelectMenCategory(string menCategory)
        {
            _sectionsListSelector.GetElements().First(item => item.Text == menCategory).Click();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void SelectMenSubcategory(string menSubcategory)
        {
            _subsectionSelector.GetElements().First(item => item.Text == menSubcategory).Click();
            WaitHelpers.WaitForDocumentReadyState();
        }
    }
}
