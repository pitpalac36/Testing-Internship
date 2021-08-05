using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class CheckoutPage
    {
        #region Selectors
        private readonly By _guestOption = By.CssSelector(".radio[value='guest']");
        private readonly By _continueButton = By.CssSelector(".button#onepage-guest-register-button");
        #endregion
    }
}
