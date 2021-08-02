using Madison.Helpers;
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
          private readonly By pageName = By.CssSelector("head > title");
          private readonly By alreadyRegisteresText = By.CssSelector(".col2-set > div:nth-child(2) >div >h2");
        private readonly By formInstructions = By.CssSelector(".col2-set > div:nth-child(2) >div >h2+p");
        
        #endregion


        /* public string CheckLogInPageDispayed()
         {
             return Driver.webDriver.FindElement(pageName).Text;

         }*/

        public string AlreadyRegisteredTextDisplayed()
        {
           return Driver.webDriver.FindElement(alreadyRegisteresText).Text;
        }

        public string CheckExistingAccountMessage()
        {
            return Driver.webDriver.FindElement(formInstructions).Text;
        }

        public void CreateAnAccountButton()
        {
            
        }
        public void FillEmail()
        {
            Driver.webDriver.FindElement(email).SendKeys("ana.ana@outlook.com");
        }


        public void FillPassword()
        {
            Driver.webDriver.FindElement(password).SendKeys("1234567");
        }

         public void FillCredentials()
        {
            FillEmail();
            FillPassword();
        }

        public void LogInSubmit()
        {
           Driver.webDriver.FindElement(loginButton).Submit();
        }

    }

}
