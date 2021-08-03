using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class ShoppingCartPage
    {
        #region Selectors
        private readonly By _confirmationMessageSelector = By.ClassName("success-msg");
        #endregion

        public bool IsSuccessMessageDisplayed()
        {
            return _confirmationMessageSelector.IsElementPresent();
        }
    }
}
