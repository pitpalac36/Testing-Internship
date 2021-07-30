using Madison.Helpers;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class MyWishlistPage
    {
        #region Selectors
        private readonly By _accountSelector = By.CssSelector(".account-cart-wrapper span+span");
        private readonly By _myWishlistSelector = By.CssSelector("a[title^='My Wishlist']");
        private readonly By _myWishlistHeaderSelector = By.CssSelector(".my-wishlist h1");
        private readonly By _firstItemQuantityCell = By.CssSelector(".first.odd input");
        private readonly By _updateWishlistFirstButton = By.CssSelector(".first.odd button");
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

        public bool IsRedirectedToWishlist()
        {
            return Driver.webDriver.FindElement(_myWishlistHeaderSelector).Displayed;
        }

        public int ChangeQuantity()
        {
            var quantityInput = Driver.webDriver.FindElement(_firstItemQuantityCell);
            var newQuantity = int.Parse(quantityInput.GetAttribute("value")) * 2;
            quantityInput.Clear();
            quantityInput.SendKeys(newQuantity.ToString());
            return newQuantity;
        }

        public void ClickOnUpdateItem()
        {
            Driver.webDriver.FindElement(_updateWishlistFirstButton).Click();
            WaitHelpers.WaitUntilDOcumentReady();
        }

        public int ItemQuantity()
        {
            return int.Parse(Driver.webDriver.FindElement(_firstItemQuantityCell).GetAttribute("value"));
        }
    }
}
