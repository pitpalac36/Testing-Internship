using Madison.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        //private readonly By _updateShoppingCart = By.CssSelector(".btn-update[title=Update Shopping Cart]:not([style=visibility: hidden;])");
        private readonly By _updateShoppingCart = By.CssSelector(".button2.btn-update:nth-child(3)");
        private readonly By _continueShopping = By.CssSelector(".button2.btn-continue");
        private readonly By _emptyShoppingCartButton = By.CssSelector("#empty_cart_button");
        private readonly By _couponCodeInputArea = By.CssSelector("#coupon_code");
        private readonly By _shoppingCartTable = By.CssSelector("#shopping-cart-table");
        private readonly By _errorMessage = By.CssSelector(".error-msg");
        private readonly By _continueShoppingLinkEmptyCart = By.CssSelector(".cart-empty > p > a");
        private readonly By _checkoutForm = By.CssSelector(".cart-forms");
        private readonly By _productPriceList = By.CssSelector(".product-cart-total");
        private readonly By _subtotalPriceLabel = By.CssSelector("td.a-right>span.price ");
        private readonly By _quantityField = By.CssSelector(".product-cart-actions > .input-text.qty");
        #endregion
        



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

        public void InsertQuantity(IWebElement inputField,string quantity)
        {
            inputField.SendKeys(quantity);
            _updateShoppingCart.ActionClick();
        }

        public IList<IWebElement> GetQuantityInputFields()
        {
            return _quantityField.GetElements();
        }



        public List<string> GetQuantity()
        {
            return _quantityField.GetElements().Select(el => el.GetAttribute("value").ToString()).ToList();
        }

        public string GetValueForInputField(IWebElement inputField)
        {
            return inputField.GetAttribute("value").ToString();
        }

        public bool CheckoutFormVisibility()
        {
            return _checkoutForm.IsElementPresent();
        }

        public bool ItemTableVisibility()
        {
            return _shoppingCartTable.IsElementPresent();
        }



        public float GetSubtotalItemsPrice()
        {
            var priceList = _productPriceList.GetElements();
            var new_list = priceList.Select(pr => pr.Text.Trim('$')).ToList(); 
            return priceList.Select(pr => float.Parse(pr.Text.Trim('$'), CultureInfo.InvariantCulture)).Sum();
        }

        public float GetSubtotalLabelPrice()
        {
            return float.Parse(_subtotalPriceLabel.GetText().Trim('$'), CultureInfo.InvariantCulture);
        }

        public void EmptyQuantityField(IWebElement quantityField)
        {
            quantityField.Clear();
        }


        public void ClickOnEmptyCartButton()
        {
            _emptyShoppingCartButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }


    }
}
