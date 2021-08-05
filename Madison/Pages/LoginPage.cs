using OpenQA.Selenium;
using NsTestFrameworkUI.Pages;

namespace Madison.Pages
{
    public class LoginPage
    {
        #region Selectors
        private readonly By _emailField = By.Id("email");
        private readonly By _passwordField = By.Id("pass");
        private readonly By _loginButton = By.Id("send2");
        private readonly By _alreadyRegisteredMessage = By.CssSelector("div.content.fieldset >h2");
        private readonly By _existingAccountMessage = By.CssSelector(".content.fieldset >h2+p");
        private readonly By _createAccountButton = By.CssSelector(".buttons-set a");
        private readonly By _messageRegisterPage = By.CssSelector(".account-create div h1");
        private readonly By _requiredMessage = By.CssSelector(".content.fieldset p.required");
        private readonly By _searchField = By.Id("search");
        private readonly By _searchResultsMessage = By.CssSelector(".page-title h1");
        private readonly By _invalidMessage = By.CssSelector(".error-msg ul li span");
        private readonly By _errorMessage = By.CssSelector("#advice-required-entry-email");
        #endregion

        public void Login(string username, string password)
        {
            _emailField.ClearField();
            _emailField.ActionSendKeys(username);
            _passwordField.ClearField();
            _passwordField.ActionSendKeys(password);
            _loginButton.ActionClick();
        }

        public string GetAlreadyRegisteredMessage()
        {
            return _alreadyRegisteredMessage.GetText();
        }

        public string GetExistingAccountMessage()
        {
            return _existingAccountMessage.GetText();
        }

        public void ClickCreateAccount()
        {
            _createAccountButton.ActionClick();
        }

        public string GetCreateAccountMessage()
        {
            return _messageRegisterPage.GetText();
        }

        public void ClickLogInBtn()
        {
            _loginButton.ActionClick();
        }

        public bool IsRequiredMessageDisplayed()
        {
            return _requiredMessage.IsElementPresent();
        }

        public void Search()
        {
            _searchField.ClearField();
            _searchField.ActionClick();
            _searchField.ActionSendKeys("shirt");
            _searchField.ActionClick();
        }
        public bool IsSearchResultsMessageDisplayed()
        {
            return _searchResultsMessage.IsElementPresent();
        }
        
        public bool IsInvalidLoginMessageDisplayed()
        {
            return _invalidMessage.IsElementPresent();
        }

        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.IsElementPresent();
        }
    }

}