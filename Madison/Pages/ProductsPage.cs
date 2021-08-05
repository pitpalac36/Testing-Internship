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
        //TODO refactor selectors
        private readonly By _productsListGridView = By.CssSelector(".products-grid.products-grid--max-4-col .item.last");
        private readonly By _sortDropdown = By.CssSelector(".toolbar-bottom div.sorter div select");
        private readonly By _sortByPrice = By.CssSelector(".toolbar-bottom div.sorter div select option:nth-child(3)");
        private readonly By _ascendingDescending = By.CssSelector(".toolbar-bottom .sort-by a");
        private readonly By _firstProductPriceGridView = By.CssSelector(".products-grid--max-4-col .item.last:nth-child(1) .price");
        private readonly By _lastProductItemGridView = By.CssSelector(".products-grid--max-4-col .item.last:last-child .price");
        private readonly By _gridView = By.CssSelector(".toolbar-bottom .grid");
        private readonly By _listView = By.CssSelector(".toolbar-bottom .list");
        private readonly By _firstItemGridView = By.CssSelector(".products-grid--max-4-col .item.last:first-child .product-name a");
        private readonly By _productPrice = By.CssSelector(".regular-price .price");
        private readonly By _productQuantity = By.CssSelector("#qty");
        private readonly By _addToCart = By.CssSelector(".add-to-cart-buttons .button");
        private readonly By _reviewLink = By.CssSelector(".rating-links a:first-child");
        private readonly By _submitReviewButton = By.CssSelector(".buttons-set .button");
        private readonly By _reviewField = By.CssSelector("#review_field");
        private readonly By _summaryField = By.CssSelector("#summary_field");
        private readonly By _nicknameField = By.CssSelector("#nickname_field");
        private readonly By _successMessage = By.CssSelector(".success-msg span");
        private readonly By _viewDetails = By.CssSelector("li:nth-child(1) .actions > a");
        private readonly By _errorList = By.CssSelector("#product-options-wrapper dd .input-box div");
        private readonly By _itemColor = By.CssSelector(".swatch-label img");
        private readonly By _sizeList = By.CssSelector("#configurable_swatch_size li");
        //private readonly By errorListSelector = By.CssSelector(".validation-advice");
        #endregion
        
        public IReadOnlyCollection<IWebElement> GetFirst12ProductsFromElectronics()
        {
            return _productsListGridView.GetElements();
        }

        public IReadOnlyCollection<IWebElement> GetErrorListSelector()
        {
            return _errorList.GetElements();
        }

        public void SelectSortByPrice() 
        {
            _sortDropdown.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            _sortByPrice.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void SetAscendingDirection()
        {
            if (_ascendingDescending.GetText() == "Set Ascending Direction")
            {
                _ascendingDescending.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void SetDescendingDirection()
        {
            if (_ascendingDescending.GetText() == "Set Descending Direction")
            {
                _ascendingDescending.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }
        public void ChangeViewMode(string viewMode) 
        {
            if (viewMode == "List" && _gridView.IsElementSelected())
            {
                _listView.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
            else if (viewMode == "Grid" && _listView.IsElementSelected()) 
            {
                _gridView.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void ClickFirstProduct()
        {
            _firstItemGridView.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void AddToCart()
        {
            _addToCart.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnReviews() 
        {
            _reviewLink.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnSubmitReviews()
        {
            _submitReviewButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ClickOnViewDetails() 
        {
            _viewDetails.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
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

        public string GetFirstProductPrice() 
        {
            return _firstProductPriceGridView.GetText();
        }

        public string GetLastProductPrice()
        {
            return _lastProductItemGridView.GetText();
        }
        public string GetItemOpenedPrice()
        {
            return _productPrice.GetText();
        }

        public void SetProductQuantity(string qty) 
        {
            _productQuantity.ActionSendKeys(qty);
        }

        public void SetReviewFields(string review, string summary, string nickname) {
            _reviewField.ClearField();
            _reviewField.ActionSendKeys(review);
            _reviewField.ClearField();
            _summaryField.ActionSendKeys(summary);
            _reviewField.ClearField();
            _nicknameField.ActionSendKeys(nickname);
        }

        public bool IsAddToCartButtonVisible()
        {
            return _addToCart.IsElementPresent();
        }

        public bool IsReviewButtonPresent() 
        {
            return _submitReviewButton.IsElementPresent();
        }

        public bool IsSuccessMessagePresent()
        {
            return _successMessage.IsElementPresent();    
        }
    }
}
