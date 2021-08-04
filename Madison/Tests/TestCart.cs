using FluentAssertions;
using Madison.Helpers;
using Madison.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Tests
{
    [TestClass]
    public class TestCart : BaseTest
    {

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { WebLinks.Earbuds, WebLinks.JACKIE_O_ROUND_SUNGLASSES,WebLinks.Aviator_Sunglasses };
            yield return new object[] { WebLinks.Earbuds };
        }

        public static IEnumerable<object[]> GetOneLink()
        {
            yield return new object[] { WebLinks.Earbuds };
            yield return new object[] { WebLinks.Aviator_Sunglasses };
            yield return new object[] { WebLinks.JACKIE_O_ROUND_SUNGLASSES };
        }


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeaderTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [TestMethod]
        public void EmptyCartVisibleContinueShopingLinkTest()
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
            string homepageUrl = ResourceFileHelper.GetValueAssociatedToString("Homepage");
            Browser.GoTo(WebLinks.CartLink);
            string cart_url = Browser.WebDriver.Url;
            Pages.MyCartPage.ClickOnContinueShoppingLinkEmptyCart();
            string redirected_url = Browser.WebDriver.Url;
            redirected_url.Should().NotBe(cart_url);
            redirected_url.Should().Be(homepageUrl);
        }

        [TestMethod]
        public void CartLabelNotDisplayedWhenCartIsEmptyTest()
        {
            Browser.GoTo(WebLinks.CartLink);
            Pages.HomePage.IsCartQuantityLabelPresent().Should().BeFalse();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CartLabelDisplayedWithItemsInCartTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Pages.HomePage.IsCartQuantityLabelPresent().Should().BeTrue();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void EmptyCartButtonDeletesCartElementsTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Pages.MyCartPage.ClickOnEmptyCartButton();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CheckMatchingSubtotalsTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Browser.GoTo(WebLinks.CartLink);
            float subtotalSum = Pages.MyCartPage.GetSubtotalItemsPrice();
            float subtotal = Pages.MyCartPage.GetSubtotalLabelPrice();
            subtotal.Should().Be(subtotalSum);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void UpdateFunctionalityTest(params string[] itemLink)
        {
            Pages.ProductDetailPage.AddItemsToCart(itemLink);
            Browser.GoTo(WebLinks.CartLink);
            List<string> initialQuantity = Pages.MyCartPage.GetQuantity();
            List<string> randomQuantity = GenerateData.GenerateNumbersListBasedOnCount(initialQuantity.Count).Select(s => s.ToString()).ToList();
            Pages.MyCartPage.UpdateQuantityList(randomQuantity);
            List<string> updatedQuantity = Pages.MyCartPage.GetQuantity();
            updatedQuantity.Should().BeEquivalentTo(randomQuantity);
            updatedQuantity.Should().NotBeEquivalentTo(initialQuantity);

        }

    }
}
