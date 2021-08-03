using Madison.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Madison.Pages
{
    public class ProductsPage
    {
        #region Selectors
        private readonly By samsungGalaxySelector = By.CssSelector("#product-collection-image-918");
        private readonly By productNameSelector = By.CssSelector(".product-name h1");
        private readonly By electronicsProductsSelector = By.CssSelector(".products-grid.products-grid--max-4-col .item.last");
        private readonly By sortSelector = By.CssSelector(".toolbar-bottom div.sorter div select");
        private readonly By sortPriceSelector = By.CssSelector(".toolbar-bottom div.sorter div select option:nth-child(3)");
        private readonly By ascendingDescendingSelector = By.CssSelector(".toolbar-bottom .sort-by a");
        private readonly By firstProductPriceSelector = By.CssSelector(".products-grid--max-4-col .item.last:nth-child(1) .price");
        private readonly By lastProductPriceSelector = By.CssSelector(".products-grid--max-4-col .item.last:last-child .price");
        private readonly By gridViewSelector = By.CssSelector(".toolbar-bottom .grid");
        private readonly By listViewSelector = By.CssSelector(".toolbar-bottom .list");
        private readonly By lastItemSelector = By.CssSelector(".products-grid--max-4-col .item.last:last-child .product-name a");
        private readonly By firstItemSelector = By.CssSelector(".products-grid--max-4-col .item.last:first-child .product-name a");
        private readonly By itemOpenedPriceSelector = By.CssSelector(".regular-price .price");
        private readonly By productQuantitySelector = By.CssSelector("#qty");
        private readonly By addToCartSelector = By.CssSelector(".add-to-cart-buttons .button");
        private readonly By reviewSelector = By.CssSelector(".rating-links a:first-child");
        private readonly By submitReviewSelector = By.CssSelector(".buttons-set .button");
        private readonly By reviewFieldSelector = By.CssSelector("#review_field");
        private readonly By summaryFieldSelector = By.CssSelector("#summary_field");
        private readonly By nicknameFieldSelector = By.CssSelector("#nickname_field");
        private readonly By successSelector = By.CssSelector(".success-msg span");

        //second flow
        private readonly By viewDetailsSelector = By.CssSelector("li:nth-child(1) .actions > a");
        private readonly By errorListSelector = By.CssSelector("#product-options-wrapper dd .input-box div");
        
        #endregion
        public IReadOnlyCollection<IWebElement> getFirst12ProductsFromElectronics()
        {
            var elems = electronicsProductsSelector.GetElements();
            return elems;
        }

        public IReadOnlyCollection<IWebElement> getErrorListSelector()
        {
            var elems = errorListSelector.GetElements();
            return elems;
        }

        /// <summary>
        /// clickers
        /// </summary>
        public void selectSortByPrice() 
        {
            sortSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            sortPriceSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void setAscendingDirection()
        {
            if (ascendingDescendingSelector.GetText() == "Set Ascending Direction")
            {
                ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void setDescendingDirection()
        {
            if (ascendingDescendingSelector.GetText() == "Set Descending Direction")
            {
                ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void changeViewMode(string viewMode) 
        {
            if (viewMode == "List" && gridViewSelector.IsElementSelected())
            {
                listViewSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
            else if (viewMode == "Grid" && listViewSelector.IsElementSelected()) 
            {
                gridViewSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void clickLastProduct() 
        {
            lastItemSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void clickFirstProduct()
        {
            firstItemSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void addToCart() 
        {
            addToCartSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void clickOnReviews() 
        {
            reviewSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void clickOnSubmitReviews()
        {
            submitReviewSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void clickOnViewDetails() {
            viewDetailsSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        /// <summary>
        /// getters
        /// </summary>
        /// <returns></returns>
        public string getFirstProductPrice() 
        {
            return firstProductPriceSelector.GetText();
        }

        public string getLastProductPrice()
        {
            return lastProductPriceSelector.GetText();
        }
        public string getItemOpenedPrice()
        {
            return itemOpenedPriceSelector.GetText();
        }

        public void setProductQuantity(string qty) 
        {
            productQuantitySelector.ActionSendKeys(qty);
        }

        public void setReview(string review) {
            reviewFieldSelector.ActionSendKeys(review);
        }

        public void setSummary(string summary) {
            summaryFieldSelector.ActionSendKeys(summary);
        }

        public void setNickname(string nickname) {
            nicknameFieldSelector.ActionSendKeys(nickname);
        }

        /// bool
        public bool isAddToCartButtonVisible()
        {
            return addToCartSelector.IsElementPresent();
        }

        public bool isReviewButtonPresent() 
        {
            return submitReviewSelector.IsElementPresent();
        }

        public bool isSuccessMessagePresent()
        {
            return successSelector.IsElementPresent();    
        }
        
    }

    

}
