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
    public class MyAccountPage
    {
        #region Selectors
        private readonly By _registerMessage = By.CssSelector(".success-msg");
        private readonly By _welcomeMessage = By.CssSelector("p.welcome-msg");
        #endregion

        public string GetWelcomeMessage()
        {
            return _welcomeMessage.GetText();
        }
    }
}
