using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Tests
{
    [TestClass]
    public class CheckoutTests : BaseTest
    {
        [TestMethod]
        public void CheckoutAsGuestTest()
        {
            //go to products
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");

            //add a product(non-configurable)
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.ClickFirstProduct();

            //go to checkout
            //select checkout as guest
            //click continue
            //complete billing information form
            //click continue
            //select free shipping
            //continue
            //continue
            //place order
            //assert thank you message

        }
    }
}
