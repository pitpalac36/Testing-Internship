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
        private readonly By _sortButton = By.CssSelector(".toolbar-bottom .sort-by a");
        private readonly By _firstProductPriceGridView = By.CssSelector(".products-grid--max-4-col .item.last:nth-child(1) .price");
        private readonly By _lastProductPriceGridView = By.CssSelector(".products-grid--max-4-col .item.last:last-child .price");
        private readonly By _gridView = By.CssSelector(".toolbar-bottom .grid");
        private readonly By _listView = By.CssSelector(".toolbar-bottom .list");
        private readonly By _firstItemImageGridView = By.CssSelector(".products-grid--max-4-col .item.last:first-child img");
        private readonly By _productPrice = By.CssSelector(".regular-price .price");
        private readonly By _productQuantity = By.CssSelector("#qty");
        private readonly By _reviewLink = By.CssSelector(".rating-links a:first-child");
        private readonly By _submitReviewButton = By.CssSelector(".buttons-set .button");
        private readonly By _reviewField = By.CssSelector("#review_field");
        private readonly By _summaryField = By.CssSelector("#summary_field");
        private readonly By _nicknameField = By.CssSelector("#nickname_field");
        private readonly By _successMessage = By.CssSelector(".success-msg span");
        private readonly By _viewDetails = By.CssSelector("li:nth-child(1) .actions > a");
        #endregion
        
        public IReadOnlyCollection<IWebElement> GetFirstProductPage()
        {
            return _productsListGridView.GetElements();
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
            if (_sortButton.GetText() == "Set Ascending Direction")
            {
                _sortButton.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void SetDescendingDirection()
        {
            if (_sortButton.GetText() == "Set Descending Direction")
            {
                _sortButton.ActionClick();
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
            _firstItemImageGridView.ActionClick();
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

        public string GetFirstProductPrice() 
        {
            return _firstProductPriceGridView.GetText();
        }

        public string GetLastProductPrice()
        {
            return _lastProductPriceGridView.GetText();
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
