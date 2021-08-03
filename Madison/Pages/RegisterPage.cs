using OpenQA.Selenium;
using NsTestFrameworkUI.Pages;
using NsTestFrameworkUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madison.Helpers;

namespace Madison.Pages
{
    public class RegisterPage
    {
        #region Selectors
        private readonly By _firstNameInputField = By.CssSelector("#firstname");
        private readonly By _middleNameInputField = By.CssSelector("#middlename");
        private readonly By _lastNameInputField = By.CssSelector("#lastname");
        private readonly By _emailInputField = By.CssSelector("#email_address");
        private readonly By _passwordInputField = By.CssSelector("#password");
        private readonly By _confirmPasswordInputField = By.CssSelector("#confirmation");
        private readonly By _newsletterButton = By.CssSelector("#is_subscribed");
        private readonly By _registerButton = By.CssSelector(".button[title=Register]");
/*        private readonly By _errorMandatoryFirstName = By.CssSelector("#advice-required-entry-firstname");
        private readonly By _errorMandatoryLastName = By.CssSelector("#advice-required-entry-lastname");
        private readonly By _errorMandatoryEmail = By.CssSelector("#advice-required-entry-email_address");
        private readonly By _errorMandatoryPassword = By.CssSelector("#advice-required-entry-password");
        private readonly By _errorMandatoryConfirmationPassword = By.CssSelector("#advice-required-entry-confirmation");*/
        private readonly By _errorList = By.CssSelector(".validation-advice");
        private readonly By _succesMessage = By.CssSelector(".success-msg li span");
        #endregion

        public void FillRegistrationForm()
        {
            _firstNameInputField.ClearField();
            _middleNameInputField.ClearField();
            _lastNameInputField.ClearField();
            _emailInputField.ClearField();
            _passwordInputField.ClearField();
            _confirmPasswordInputField.ClearField();

            _firstNameInputField.ActionSendKeys(UserDetails.FirstName);
            _middleNameInputField.ActionSendKeys(UserDetails.MiddleName);
            _lastNameInputField.ActionSendKeys(UserDetails.LastName);
            _emailInputField.ActionSendKeys(UserDetails.EmailAddress);
            _passwordInputField.ActionSendKeys(UserDetails.Password);
            _confirmPasswordInputField.ActionSendKeys(UserDetails.ConfirmPassword);
        }

        public void SubscribeToNewsletter()
        {
           // _newsletterButton.ClearField();  DA EROARE CU EA 
            _newsletterButton.ActionClick();
        }

        public void ClickRegisterButton()
        {
            _registerButton.ActionClick();
        }


        public List<string> GetErrorMessagesFromForm()
        {
            return _errorList.GetElements().Select(el => el.Text).ToList();
        }

        public string GetSuccessMessage()
        {
            return _succesMessage.GetText();
        }

        public string MergeUserNameWithWelcome()
        {
            return "WELCOME, " + UserDetails.FirstName.ToUpper() + " " + UserDetails.MiddleName.ToUpper() + " " + UserDetails.LastName.ToUpper() + "";
        }
    }
}
