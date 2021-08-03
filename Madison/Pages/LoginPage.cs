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
        private readonly By _welcomeMessage = By.CssSelector("p.welcome-msg");
        #endregion

       /* public void FillCredentials(string username, string password)
        {
            _emailTextField.ClearField();
            _emailTextField.ActionSendKeys(username);
            _passwordTextField.ClearField();
            _passwordTextField.ActionSendKeys(password);
        }*/
        public void Login(string username, string password)
        {
            _emailTextField.ClearField();
            _emailTextField.ActionSendKeys(username);
            _passwordTextField.ClearField();
            _passwordTextField.ActionSendKeys(password);
            //FillCredentials(ResourceFileHelper.Usernames[0], ResourceFileHelper.Passwords[0]);
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

       public string GetWelcomeMessage()
        {
            return _welcomeMessage.GetText();
        }

    }

}