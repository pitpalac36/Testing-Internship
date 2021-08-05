using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
namespace Madison.Pages
{
    public class ProductDetailPage
    {
        #region selectors
             private readonly By _addToCartButton = By.CssSelector(".button.btn-cart:nth-child(1)");
             private readonly By _quantityInput = By.Id("qty");
             private readonly By _updateButton = By.CssSelector("a.link-compare");
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

        public void EditWishlistItemQuantity(string quantity)
        {
            _quantityInput.ClearField();
            _quantityInput.ActionSendKeys(quantity);
        }

        public void UpdateWishlist()
        {
            _updateButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

    }
}
