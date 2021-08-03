using Madison.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class LoginPage
    {
        #region Selectors
        //There is no need to specify the element type in the method name. is enough if you specify it in the name of the selector
        private readonly By _emailTextField = By.Id("email");
        private readonly By _passwordTextField = By.Id("pass");
        private readonly By _loginButton = By.Id("send2");
        private readonly By _alreadyRegisteredText = By.CssSelector("div.content.fieldset >h2");
        private readonly By _existingAccountMessage = By.CssSelector(".content.fieldset >h2+p");
        #endregion

        public void FillCredentials()
        {
            _emailTextField.ClearField();
            _emailTextField.ActionSendKeys(ResourceFileHelper.Usernames[0]);
            _passwordTextField.ClearField();
            _passwordTextField.ActionSendKeys(ResourceFileHelper.Passwords[0]);
        }
        public void Login()
        {
            FillCredentials();
            _loginButton.ActionClick();
        }

        public string AlreadyRegisteredTextDisplayed()
        {
            return _alreadyRegisteredText.GetText();
        }

        public string CheckExistingAccountMessage()
        {
            return _existingAccountMessage.GetText();
        }

       

    }

}