using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

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
        private readonly By _createAccountButton = By.CssSelector(".buttons-set a");
        private readonly By _messageToCheckRegisterPage = By.CssSelector(".account-create div h1");
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
            _loginButton.ActionClick();
        }

        public string GetAlreadyRegisteredMessage()
        {
            return _alreadyRegisteredText.GetText();
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
            return _messageToCheckRegisterPage.GetText();
        }
    }

}