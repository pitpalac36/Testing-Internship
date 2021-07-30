using Madison.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class MyCartPage
    {
        #region Selectors
        private readonly By _shoppingCartHeader = By.CssSelector("h1");
        private readonly By _emptyCartButton = By.CssSelector(".button2.btn-update:nth-child(3)");
        private readonly By _continueShopping = By.CssSelector(".button2.btn-continue");
        private readonly By _couponCodeInputArea = By.CssSelector("#coupon_code");
        private readonly By _shoppingCartTable = By.CssSelector("#shopping-cart-table");
        private readonly By _cartLabel = By.CssSelector(".count");
        private readonly By _errorMessage = By.CssSelector(".error-msg");
        private readonly By _continueShoppingLinkEmptyCart = By.CssSelector(".cart-empty > p > a");
        private readonly By _checkoutForm = By.CssSelector(".cart-forms");
        #endregion
        

        public void AddItemToCart()
        {
            string itemLink = ResourceFileHelper.GetValueAssociatedToString("Earbuds");
            Driver.webDriver.Navigate().GoToUrl(itemLink);
            WaitHelpers.WaitUntilDocumentReady();
            By addToCartButton = By.CssSelector(".button.btn-cart:nth-child(1)");
            Driver.webDriver.FindElement(addToCartButton).Click();
        }

        public string GetHeaderMessage()
        {
            return Driver.webDriver.FindElement(_shoppingCartHeader).Text;
        }

        public bool ContinueShoppingLinkEmptyIsVisible()
        {
            return Driver.webDriver.FindElement(_continueShoppingLinkEmptyCart).Displayed;
        }

        public void ClickOnContinueShoppingLinkEmptyCart()
        {
            Driver.webDriver.FindElement(_continueShoppingLinkEmptyCart).Click();
            WaitHelpers.WaitUntilDocumentReady();
        }

        public bool CheckoutFormVisibility()
        {
            return Driver.webDriver.FindElement(_checkoutForm).Displayed;
        }

        public bool CartLabelVisibility()
        {
            return Driver.webDriver.FindElement(_cartLabel).Displayed;
        }

        public bool ItemTableVisibility()
        {
            return Driver.webDriver.FindElement(_shoppingCartTable).Displayed;
        }

        public void GoToCart()
        {
            string cartUrl = ResourceFileHelper.GetValueAssociatedToString("CartLink"); 
            Driver.webDriver.Navigate().GoToUrl(cartUrl);
            WaitHelpers.WaitUntilDocumentReady();
        }


    }
}
