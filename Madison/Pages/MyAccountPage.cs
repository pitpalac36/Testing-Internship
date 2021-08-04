using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class MyAccountPage
    {
        #region Selectors
        private readonly By _welcomeMessage = By.CssSelector("p.welcome-msg");
        #endregion

        public string GetWelcomeMessage()
        {
            return _welcomeMessage.GetText();
        }
    }
}
