using Madison.Helpers;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class MyWishlistPage
    {
        #region Selectors
        private static readonly By _accountSelector = By.CssSelector(".account-cart-wrapper span+span");
        private static readonly By _myWishlistSelector = By.CssSelector("a[title^='My Wishlist']");
        #endregion

        public void ClickOnAccount()
        {
            Driver.webDriver.FindElement(_accountSelector).Click();
        }

        public bool IsWishlistButtonDisplayed()
        {
            return Driver.webDriver.FindElement(_myWishlistSelector).Displayed;
        }

        public void ClickOMyWishlist()
        {
            Driver.webDriver.FindElement(_myWishlistSelector).Click();
            WaitHelpers.WaitUntilDOcumentReady();
        }
    }
}
