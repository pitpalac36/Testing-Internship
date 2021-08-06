using NsTestFrameworkUI.Pages;
using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class MagentoLoginAdminPage
    {
        #region Selectors
        private readonly By _usernameInputSelector = By.CssSelector("input#username");
        private readonly By _passwordInputSelector = By.CssSelector("input#login");
        private readonly By _loginSubmitSelector = By.CssSelector(".form-button");
        private readonly By _popupCloseSelector = By.CssSelector(".message-popup-head a");
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

        public void ClickOnClosePopup()
        {
            _popupCloseSelector.ActionClick();
        }

    }
}
