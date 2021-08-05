using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Madison.Pages
{
    public class ProductDetailPage
    {
        #region selectors
            private readonly By _addToCartButton = By.CssSelector(".button.btn-cart:nth-child(1)");
            private readonly By _errorList = By.CssSelector("#product-options-wrapper dd .input-box div");
            private readonly By _itemColor = By.CssSelector(".swatch-label img");
            private readonly By _sizeList = By.CssSelector("#configurable_swatch_size li");
            private readonly By _addToCart = By.CssSelector(".add-to-cart-buttons .button");
        #endregion

        public void AddItemToCart(string itemLink)
        {
            Browser.GoTo(itemLink);
            WaitHelpers.WaitForDocumentReadyState();
            _addToCartButton.ActionClick();
        }

        public void AddItemsToCart(string[] itemLinks)
        {
            foreach (string item in itemLinks)
            {
                AddItemToCart(item);
            }
        }
        public IReadOnlyCollection<IWebElement> GetErrorListSelector()
        {
            return _errorList.GetElements();
        }
        public string SelectColor()
        {
            _itemColor.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            return _itemColor.GetAttribute("alt");
        }
        public string SelectSize()
        {
            Random rnd = new();
            int randomInt = rnd.Next(0, _sizeList.GetElements().Count);
            var size = _sizeList.GetElements().ElementAt(randomInt).GetAttribute("value");
            _sizeList.GetElements().ElementAt(randomInt).Click();
            WaitHelpers.WaitForDocumentReadyState();
            return size;
        }
        public void AddToCart()
        {
            _addToCart.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }
        public bool IsAddToCartButtonVisible()
        {
            return _addToCart.IsElementPresent();
        }
    }
}
