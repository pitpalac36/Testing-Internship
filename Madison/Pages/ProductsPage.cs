using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Pages
{
    public class ProductsPage
    {
        #region Selectors
        private readonly By samsungGalaxySelector = By.CssSelector("#product-collection-image-918");
        private readonly By productNameSelector = By.CssSelector(".product-name h1");
        
        #endregion
    }
}
