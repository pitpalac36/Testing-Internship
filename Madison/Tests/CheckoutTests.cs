using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Pages.ProductDetailPage.AddToCart();
            //go to checkout
            Pages.HomePage.SelectMyAccountMenu("Checkout");
            //select checkout as guest
            Pages.CheckoutPage.ClickCheckoutAsGuest();
            //click continue
            Pages.CheckoutPage.ClickContinueCheckout();
            //complete billing information form
            Pages.CheckoutPage.FillBillingForm();
            //click continue
            Pages.CheckoutPage.ClickContinueFromBilling();
            //select free shipping
            Pages.CheckoutPage.ApplyFreeShipping();
            //continue
            Pages.CheckoutPage.ClickContinueFromShippingMethod();
            //continue
            Pages.CheckoutPage.ClickContinuePayment();
            //place order
            Pages.CheckoutPage.PlaceOrder();
            //Thread.Sleep(10000);
            //assert thank you message
            Pages.CheckoutPage.IsSuccessMessageDisplayedAfterCheckout().Should().BeTrue();

        }
    }
}
