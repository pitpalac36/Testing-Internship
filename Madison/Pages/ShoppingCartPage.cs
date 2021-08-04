using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Madison.Pages
{
    public class ShoppingCartPage
    {
        #region Selectors
        private readonly By _confirmationMessageSelector = By.ClassName("success-msg");
        private readonly By _firstItemColorSelector = By.CssSelector("td.product-cart-info dd:nth-child(2)");
        private readonly By _firstItemSizeSelector = By.CssSelector("td.product-cart-info dd:nth-child(4)");
        #endregion

        public bool IsSuccessMessageDisplayed()
        {
            return _confirmationMessageSelector.IsElementPresent();
        }

        public string FirstItemColor()
        {
            return _firstItemColorSelector.GetText();
        }

        public string FirstItemSize()
        {
            return _firstItemSizeSelector.GetText();
        }
    }
}
