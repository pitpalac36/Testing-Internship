using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Madison.Pages
{
    public class HomePage
    {
        #region Selectors
        private readonly By _navigationBarList = By.CssSelector("#nav ol li.level0 > a");
        private readonly By _navigationBar = By.CssSelector(".nav-primary");
        private readonly By _homeDecorImage = By.CssSelector(".category-image");
        private readonly By _electronicsSubcategoryList = By.CssSelector(".catblocks li");
        private readonly By _categoryTitle = By.CssSelector(".page-title.category-title h1");
        private readonly By _accountElement = By.CssSelector(".account-cart-wrapper > a");
        private readonly By _menuElements = By.CssSelector("#header-account>.links>ul li");
        private readonly By _cartQuantityLabel = By.CssSelector(".count");
        private readonly By _navigationBarSubsection = By.CssSelector(".catblocks li a");
        #endregion

        public bool IsCartQuantityLabelPresent()
        {
            return _cartQuantityLabel.IsElementPresent();
        }

        public void SelectHomeDecorSubcategory (string homePageSubcategory )
        {
            _electronicsSubcategoryList.GetElements().First(item => item.Text.ToLower() == homePageSubcategory.ToLower()).Click();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public IReadOnlyCollection<IWebElement> GetSectionsList()
        {
            var elems = _navigationBarList.GetElements();
            return elems;
        }
        public bool CheckIfProductSectionsIsVisible() {
            var elems = _navigationBar.IsElementPresent();
            return elems;
        }

        public bool CheckIfHomeMainImageIsVisible() {
            var elem =  _homeDecorImage.IsElementPresent();
            return elem;
        }

        public bool CheckIfCategoryTitleIsVisible() {
            var elem = _categoryTitle.IsElementPresent();
            return elem;
        }

        public void ClickOnAccount()
        {
            _accountElement.ActionClick();
        }

        public void SelectMyAccountMenu (string accountMenu )
        {
            ClickOnAccount();
            _menuElements.GetElements().First(item => item.Text == accountMenu).Click();
        }
        public void SelectCategory (string category )
        {
            _navigationBarList.GetElements().First(item => item.Text.ToLower() == category.ToLower()).Click();
            WaitHelpers.WaitForDocumentReadyState();
        }
        public void SelectMenSubcategory (string menSubcategory )
        {
            _navigationBarSubsection.GetElements().First(item => item.Text.ToLower() == menSubcategory.ToLower()).Click();
            WaitHelpers.WaitForDocumentReadyState();
        }
    }
}
