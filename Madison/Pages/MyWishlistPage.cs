using Madison.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
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
        private readonly By _updateWishlistBigButton = By.CssSelector(".buttons-set.buttons-set2 button+button+button");
        private readonly By _shareWishlistButton = By.CssSelector(".buttons-set.buttons-set2 button");
        private readonly By _shareWishlistForm = By.CssSelector(".col-main");
        private readonly By _shareWishlistEmailTextArea = By.CssSelector("textarea[Name='emails']");
        private readonly By _shareWishlistFinalButton = By.CssSelector(".form-buttons button");
        private readonly By _validationAdviceLabel = By.ClassName("validation-advice");
        #endregion

        public void ClickOnAccount()
        {
            _accountSelector.ActionClick();
        }

        public bool IsWishlistButtonDisplayed()
        {
           return _myWishlistSelector.IsElementPresent();
        }

        public void ClickOMyWishlist()
        {
            _myWishlistSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsRedirectedToWishlist()
        {
            return _myWishlistHeaderSelector.IsElementPresent();
        }

        public int ChangeQuantity()
        {
            var quantityInput = _firstItemQuantityCell.GetAttribute("value");
            var newQuantity = int.Parse(quantityInput) * 2;
            _firstItemQuantityCell.ClearField();
            _firstItemQuantityCell.ActionSendKeys(newQuantity.ToString());
            return newQuantity;
        }

        public void ClickOnUpdateItem()
        {
            _updateWishlistFirstButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnUpdateWishlist()
        {
            _updateWishlistBigButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public int ItemQuantity()
        {
            return int.Parse(_firstItemQuantityCell.GetAttribute("value"));
        }

        public void ClickOnShareWishlist()
        {
            _shareWishlistButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public string GetUrl()
        {
            return Browser.WebDriver.Url;
        }

        public bool IsShareWishlistFormDisplayed()
        {
            return _shareWishlistForm.IsElementPresent();
        }

        public void FillEmail(string email)
        {
            var textarea = _shareWishlistEmailTextArea.GetText();
            _shareWishlistEmailTextArea.ClearField();
            _shareWishlistEmailTextArea.ActionSendKeys(email);
        }

        public void ClickOnShareWishlistButton()
        {
            _shareWishlistFinalButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsRequiredValidationAdviceDisplayed()
        {
            return _validationAdviceLabel.IsElementPresent();
        }

        public string GetRequiredValidationAdvice()
        {
            return _validationAdviceLabel.GetText();
        }
    }
}
