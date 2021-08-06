using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Madison.Tests
{
    [TestClass]
    public class CheckoutTests : BaseTest
    {
        [TestMethod]
        public void CheckoutAsGuestTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductDetailPage.AddToCart();
            Pages.HomePage.SelectMyAccountMenu("Checkout");
            Pages.CheckoutPage.ClickCheckoutAsGuest();
            Pages.CheckoutPage.ClickContinueCheckout();
            Pages.CheckoutPage.FillBillingForm();
            Pages.CheckoutPage.ClickContinueFromBilling();
            Pages.CheckoutPage.ApplyFreeShipping();
            Pages.CheckoutPage.ClickContinueFromShippingMethod();
            Pages.CheckoutPage.ClickContinuePayment();
            Pages.CheckoutPage.PlaceOrder();

            Pages.CheckoutPage.IsSuccessMessageDisplayedAfterCheckout().Should().BeTrue();

        }
    }
}
