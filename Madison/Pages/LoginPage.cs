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
          private readonly By email = By.Id("email");
          private readonly By password = By.Id("pass");
          private readonly By loginButton = By.Id("send2");
        #endregion



        public void FillEmail()
        {
            email.ActionSendKeys("ana.ana@outlook.com");
        }


        public void FillPassword()
        {
            password.ActionSendKeys("1234567");
        }

         public void FillCredentials()
        {
            FillEmail();
            FillPassword();
        }

        public void LogInSubmit()
        {
            loginButton.ActionClick();
           //Driver.webDriver.FindElement(loginButton).Submit();
        }

    }

}
