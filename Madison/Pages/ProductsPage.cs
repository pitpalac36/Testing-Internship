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
        private readonly By firstProductSelector = By.CssSelector(".products-grid.products-grid--max-4-col .item.last:nth-child(1) .price");
        private readonly By lastProductSelector = By.CssSelector(".products-grid.products-grid--max-4-col .item.last:last-child .price");
        #endregion
        public IReadOnlyCollection<IWebElement> getFirst12ProductsFromElectronics()
        {
            var elems = electronicsProductsSelector.GetElements();
            return elems;
        }

        /// <summary>
        /// clickers
        /// </summary>
        public void selectSortByPrice() {
            sortSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
            sortPriceSelector.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void setAscendingDirection() {
            if (ascendingDescendingSelector.GetText() == "Set Ascending Direction")
            {
                ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        public void setDescendingDirection(){
            if (ascendingDescendingSelector.GetText() == "Set Descending Direction")
            {
                ascendingDescendingSelector.ActionClick();
                WaitHelpers.WaitForDocumentReadyState();
            }
        }

        /// <summary>
        /// getters
        /// </summary>
        /// <returns></returns>
        public string getFirstProductPrice() {
            return firstProductSelector.GetText();
        }

        public string getLastProductPrice()
        {
            return lastProductSelector.GetText();
        }
    }

    

}
