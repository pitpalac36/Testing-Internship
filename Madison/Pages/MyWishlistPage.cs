using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class MyWishlistPage
    {
        #region Selectors
        private readonly By _myWishlistLink = By.CssSelector("a[title^='My Wishlist']");
        private readonly By _myWishlistHeader = By.CssSelector(".my-wishlist h1");
        private readonly By _firstItemQuantityCell = By.CssSelector("#wishlist-view-form .first .qty");
        private readonly By _updateWishlistFirstButton = By.CssSelector("#wishlist-table button");
        private readonly By _updateWishlistFinalButton = By.CssSelector(".buttons-set2 .btn-update");
        private readonly By _shareWishlistButton = By.CssSelector(".buttons-set [name='save_and_share']");
        private readonly By _shareWishlistForm = By.CssSelector(".col-main");
        private readonly By _shareWishlistEmailTextArea = By.CssSelector("textarea[Name='emails']");
        private readonly By _shareWishlistFinalButton = By.CssSelector(".form-buttons button");
        private readonly By _validationAdviceLabel = By.ClassName("validation-advice");
        private readonly By _commentTextArea = By.CssSelector("textarea[name^='description']");
        private readonly By _editItemButton = By.CssSelector(".link-edit");
        private readonly By _quantityInputFromShowroom = By.Id("qty");
        private readonly By _updateFromShowroomButton = By.CssSelector("a.link-compare");
        private readonly By _errorMessage = By.ClassName("error-msg");
        #endregion

        public bool IsWishlistButtonDisplayed()
        {
            return _myWishlistLink.IsElementPresent();
        }

        public void ClickOnMyWishlist()
        {
            _myWishlistLink.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsRedirectedToWishlist()
        {
            return _myWishlistHeader.IsElementPresent();
        }

        public void ChangeQuantity(string newQuantity)
        {
            _firstItemQuantityCell.ClearField();
            _firstItemQuantityCell.ActionSendKeys(newQuantity);
        }

        public void UpdateItem()
        {
            _updateWishlistFirstButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void UpdateWishlist()
        {
            _updateWishlistFinalButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public string ItemQuantity()
        {
            return _firstItemQuantityCell.GetAttribute("value");
        }

        public void ShareWishlist()
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
            _shareWishlistEmailTextArea.ClearField();
            _shareWishlistEmailTextArea.ActionSendKeys(email);
        }

        public void ShareWishlistFinal()
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

        public void InsertComment(string comment)
        {
            _commentTextArea.ClearField();
            _commentTextArea.ActionSendKeys(comment);
        }

        public string ItemComment()
        {
            return _commentTextArea.GetAttribute("value");
        }

        public void ClickOnEdit()
        {
            _editItemButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void EditQuantityFromShowroom(string quantity)
        {
            _quantityInputFromShowroom.ClearField();
            _quantityInputFromShowroom.ActionSendKeys(quantity);
        }

        public void UpdateWishlistFromShowroom()
        {
            _updateFromShowroomButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.IsElementPresent();
        }      
    }
}
