using NsTestFrameworkUI.Pages;
using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class MagentoLoginAdminPage
    {
        #region Selectors
        private readonly By _usernameInputSelector = By.CssSelector("input#username");
        private readonly By _passwordInputSelector = By.CssSelector("input#login");
        private readonly By _loginSubmitSelector = By.CssSelector(".form-button");
        #endregion

        private void FillUsername(string username)
        {
            _usernameInputSelector.ActionSendKeys(username);
        }

        private void FillPassword(string password)
        {
            _passwordInputSelector.ActionSendKeys(password);
        }

        private void ClickLogin()
        {
            _loginSubmitSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void Login(string username, string password)
        {
            FillUsername(username);
            FillPassword(password);
            ClickLogin();
        }
    }
}
