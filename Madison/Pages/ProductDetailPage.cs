using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class ProductDetailPage
    {
        #region selectors
             private readonly By _addToCartButton = By.CssSelector(".button.btn-cart:nth-child(1)");
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

    }
}
