using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using System.Collections.Generic;
using System.Linq;


namespace Madison.Tests
{
    [TestClass]
    public class TestCart : BaseTest
    {

        public static IEnumerable<object[]> GetArrayOfItemsLinks()
        {
            yield return new object[] { WebLinks.Earbuds, WebLinks.JACKIE_O_ROUND_SUNGLASSES,WebLinks.Aviator_Sunglasses };
            yield return new object[] { WebLinks.Earbuds };
        }


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeaderTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.MyCartPage.GetHeaderMessage().Should().Be(Messages.Empty_Cart_Message);
        }

        [TestMethod]
        public void ContinueShoppingVisibleWhenCartEmptyTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.MyCartPage.ContinueShoppingLinkEmptyIsVisible().Should().BeTrue();
        }

        [TestMethod]
        public void CartTableNotVisibleWhenEmptyTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.MyCartPage.ItemTableVisibility().Should().BeFalse();
        }

        [TestMethod]
        public void CartCheckoutFormNotVisibleWhenEmptyTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.MyCartPage.CheckoutFormVisibility().Should().BeFalse();
        }
        
        [TestMethod]
        public void ContinueShoppingLinkRedirectsToHomePageTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            string cart_url = Pages.GetUrl();
            Pages.MyCartPage.ClickOnContinueShoppingLinkEmptyCart();
            string redirected_url = Pages.GetUrl();
            redirected_url.Should().NotBe(cart_url);
            redirected_url.Should().Be(WebLinks.Homepage);
        }

        [TestMethod]
        public void CartLabelNotDisplayedWhenCartIsEmptyTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.HomePage.IsCartQuantityLabelPresent().Should().BeFalse();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetArrayOfItemsLinks), DynamicDataSourceType.Method)]
        public void CartLabelDisplayedWithItemsInCartTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Pages.HomePage.IsCartQuantityLabelPresent().Should().BeTrue();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetArrayOfItemsLinks), DynamicDataSourceType.Method)]
        public void EmptyCartButtonDeletesCartElementsTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Pages.MyCartPage.ClickOnEmptyCartButton();
            Pages.MyCartPage.GetHeaderMessage().Should().Be(Messages.Empty_Cart_Message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetArrayOfItemsLinks), DynamicDataSourceType.Method)]
        public void CheckMatchingSubtotalsTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Browser.GoTo(WebLinks.CartLink);
            Pages.MyCartPage.GetSubtotalItemsPrice().Should().Be(Pages.MyCartPage.GetSubtotalLabelPrice());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetArrayOfItemsLinks), DynamicDataSourceType.Method)]
        public void UpdateQuantityTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Browser.GoTo(WebLinks.CartLink);
            var initialQuantity = Pages.MyCartPage.GetQuantities();
            var randomQuantity = GenerateData.GenerateNumbersListBasedOnCount(initialQuantity.Count).Select(s => s.ToString()).ToList();
            Pages.MyCartPage.UpdateQuantityList(randomQuantity);
            var updatedQuantity = Pages.MyCartPage.GetQuantities();
            updatedQuantity.Should().BeEquivalentTo(randomQuantity);
            updatedQuantity.Should().NotBeEquivalentTo(initialQuantity);
        }
    }
}
