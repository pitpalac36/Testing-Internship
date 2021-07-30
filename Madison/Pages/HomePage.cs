using Madison.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class HomePage
    {

        #region Selectors

         private readonly By accountElement = By.CssSelector(".account-cart-wrapper > a");
         private readonly By menuElements = By.CssSelector("#header-account>.links>ul li");
        #endregion

        public void ClickOnAccount()
        {
            Driver.webDriver.FindElement(accountElement).Click();
        }

        private void SelectMyAccountMenu(string accountMenu)
        {
            Driver.webDriver.FindElements(menuElements).First(item => item.Text == accountMenu).Click();
        }

        public void ClickLogInButton()
        {
            SelectMyAccountMenu("Log In");
           
        }
    }
}
