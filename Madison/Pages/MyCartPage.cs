using Madison.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
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
        private readonly By _emptyCartButton = By.CssSelector(".btn-update[title="+ "Update Shopping Cart"+ "]:not([style=" +"visibility: hidden;" +"])");
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
            Browser.GoTo(itemLink);
            WaitHelpers.WaitForDocumentReadyState();
            By addToCartButton = By.CssSelector(".button.btn-cart:nth-child(1)");
            addToCartButton.ActionClick();
        }

        public string GetHeaderMessage()
        {
            return _shoppingCartHeader.GetText();
        }

        public bool ContinueShoppingLinkEmptyIsVisible()
        {
            return _continueShoppingLinkEmptyCart.IsElementPresent();
        }

        public void ClickOnContinueShoppingLinkEmptyCart()
        {
            _continueShoppingLinkEmptyCart.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public bool CheckoutFormVisibility()
        {
            return _checkoutForm.IsElementPresent();
        }

        public bool CartLabelVisibility()
        {
            return _cartLabel.IsElementPresent();
        }

        public bool ItemTableVisibility()
        {
            return _shoppingCartTable.IsElementPresent();
        }

        public void GoToCart()
        {
            string cartUrl = ResourceFileHelper.GetValueAssociatedToString("CartLink");
            Browser.GoTo(cartUrl);
            WaitHelpers.WaitForDocumentReadyState();
        }


    }
}
