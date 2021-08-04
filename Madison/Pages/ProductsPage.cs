using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Madison.Pages
{
    public class ProductsPage
    {
        #region Selectors
        private readonly By _electronicsProductsSelector = By.CssSelector(".products-grid.products-grid--max-4-col .item.last");
        private readonly By _sortSelector = By.CssSelector(".toolbar-bottom div.sorter div select");
        private readonly By _sortPriceSelector = By.CssSelector(".toolbar-bottom div.sorter div select option:nth-child(3)");
        private readonly By _ascendingDescendingSelector = By.CssSelector(".toolbar-bottom .sort-by a");
        private readonly By _firstProductPriceSelector = By.CssSelector(".products-grid--max-4-col .item.last:nth-child(1) .price");
        private readonly By _lastProductPriceSelector = By.CssSelector(".products-grid--max-4-col .item.last:last-child .price");
        private readonly By _gridViewSelector = By.CssSelector(".toolbar-bottom .grid");
        private readonly By _listViewSelector = By.CssSelector(".toolbar-bottom .list");
        private readonly By _lastItemSelector = By.CssSelector(".products-grid--max-4-col .item.last:last-child .product-name a");
        private readonly By _firstItemSelector = By.CssSelector(".products-grid--max-4-col .item.last:first-child .product-name a");
        private readonly By _itemOpenedPriceSelector = By.CssSelector(".regular-price .price");
        private readonly By _productQuantitySelector = By.CssSelector("#qty");
        private readonly By _addToCartSelector = By.CssSelector(".add-to-cart-buttons .button");
        private readonly By _reviewSelector = By.CssSelector(".rating-links a:first-child");
        private readonly By _submitReviewSelector = By.CssSelector(".buttons-set .button");
        private readonly By _reviewFieldSelector = By.CssSelector("#review_field");
        private readonly By _summaryFieldSelector = By.CssSelector("#summary_field");
        private readonly By _nicknameFieldSelector = By.CssSelector("#nickname_field");
        private readonly By _successSelector = By.CssSelector(".success-msg span");
        private readonly By _viewDetailsSelector = By.CssSelector("li:nth-child(1) .actions > a");
        private readonly By _errorListSelector = By.CssSelector("#product-options-wrapper dd .input-box div");
        private readonly By _colorSelector = By.CssSelector(".swatch-label img");
        private readonly By _sizeListSelector = By.CssSelector("#configurable_swatch_size li");
        //private readonly By errorListSelector = By.CssSelector(".validation-advice");
        
        #endregion
        public IReadOnlyCollection<IWebElement> GetFirst12ProductsFromElectronics()
        {
            var elems = _electronicsProductsSelector.GetElements();
            return elems;
        }

        public IReadOnlyCollection<IWebElement> GetErrorListSelector()
        {
            return _errorListSelector.GetElements();
        }

        public void SelectSortByPrice() 
        {
            _sortSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            _sortPriceSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void SetAscendingDirection()
        {
            if (_ascendingDescendingSelector.GetText() == "Set Ascending Direction")
            {
                _ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void SetDescendingDirection()
        {
            if (_ascendingDescendingSelector.GetText() == "Set Descending Direction")
            {
                _ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }
        public void ChangeViewMode(string viewMode) 
        {
            if (viewMode == "List" && _gridViewSelector.IsElementSelected())
            {
                _listViewSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
            else if (viewMode == "Grid" && _listViewSelector.IsElementSelected()) 
            {
                _gridViewSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void ClickLastProduct() 
        {
            _lastItemSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickFirstProduct()
        {
            _firstItemSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void AddToCart()
        {
            _addToCartSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnReviews() 
        {
            _reviewSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnSubmitReviews()
        {
            _submitReviewSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnViewDetails() 
        {
            _viewDetailsSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public string SelectColor()
        {
            _colorSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            return _colorSelector.GetAttribute("alt");
        }
        public string SelectSize()
        {
            Random rnd = new();
            int randomInt = rnd.Next(0, _sizeListSelector.GetElements().Count);
            var size = _sizeListSelector.GetElements().ElementAt(randomInt).GetAttribute("value");
            _sizeListSelector.GetElements().ElementAt(randomInt).Click();
            WaitHelpers.WaitForDocumentReadyState();
            return size;
        }

        public string GetFirstProductPrice() 
        {
            return _firstProductPriceSelector.GetText();
        }

        public string GetLastProductPrice()
        {
            return _lastProductPriceSelector.GetText();
        }
        public string GetItemOpenedPrice()
        {
            return _itemOpenedPriceSelector.GetText();
        }

        public void SetProductQuantity(string qty) 
        {
            _productQuantitySelector.ActionSendKeys(qty);
        }

        public void SetReview(string review) {
            _reviewFieldSelector.ActionSendKeys(review);
        }

        public void SetSummary(string summary) {
            _summaryFieldSelector.ActionSendKeys(summary);
        }

        public void SetNickname(string nickname) {
            _nicknameFieldSelector.ActionSendKeys(nickname);
        }
        public bool IsAddToCartButtonVisible()
        {
            return _addToCartSelector.IsElementPresent();
        }

        public bool IsReviewButtonPresent() 
        {
            return _submitReviewSelector.IsElementPresent();
        }

        public bool IsSuccessMessagePresent()
        {
            return _successSelector.IsElementPresent();    
        }
    }
}
