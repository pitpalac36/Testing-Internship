﻿using FluentAssertions;
using Madison.Helpers;
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
        }

        public static IEnumerable<object[]> GetOneLink()
        {
            yield return new object[] { WebLinks.Earbuds };
            yield return new object[] { WebLinks.Aviator_Sunglasses };
            yield return new object[] { WebLinks.JACKIE_O_ROUND_SUNGLASSES };
        }


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeader()
        {
            Browser.GoTo(WebLinks.CartLink);
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [TestMethod]
        public void EmptyCartVisibleContinueShopingLink()
        {
            Browser.GoTo(WebLinks.CartLink);
            bool displayed = Pages.MyCartPage.ContinueShoppingLinkEmptyIsVisible();
            displayed.Should().BeTrue();
        }

        [TestMethod]
        public void CartTableNotVisibleEmpty()
        {
            Browser.GoTo(WebLinks.CartLink);
            bool displayed = Pages.MyCartPage.ItemTableVisibility();
            displayed.Should().BeFalse();

            
        }

        [TestMethod]
        public void CartCheckoutFormNotVisibleWhenEmpty()
        {
            //Pages.MyCartPage.GoToCart();
            Browser.GoTo(WebLinks.CartLink);
            bool displayed = Pages.MyCartPage.CheckoutFormVisibility();
            displayed.Should().BeFalse();
            
        }
        
        [TestMethod]
        public void ContinueShoppingLinkRedirectsToHomePage()
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
        public void CartLabelNotDisplayedWhenCartIsEmpty()
        {
            Browser.GoTo(WebLinks.CartLink);
            bool visibility = Pages.MyCartPage.CartLabelVisibility();
            visibility.Should().BeFalse();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CartLabelDisplayedWithItemsInCart(params string[] itemLink)
        {
            foreach(string link in itemLink)
            {
                Pages.MyCartPage.AddItemToCart(link);
            }
            bool visibility = Pages.MyCartPage.CartLabelVisibility();
            visibility.Should().BeTrue();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void EmptyCartButtonDeletesCartElements(params string[] itemLink)
        {
            foreach (string link in itemLink)
            {
                Pages.MyCartPage.AddItemToCart(link);
            }
            Pages.MyCartPage.ClickOnEmptyCartButton();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CheckMatchingSubtotals(params string[] itemLink)
        {
            foreach (string link in itemLink)
            {
                Pages.MyCartPage.AddItemToCart(link);
            }
            Browser.GoTo(WebLinks.CartLink);
            float subtotalSum = Pages.MyCartPage.GetSubtotalItemsPrice();
            float subtotal = Pages.MyCartPage.GetSubtotalLabelPrice();
            subtotal.Should().Be(subtotalSum);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOneLink), DynamicDataSourceType.Method)]
        public void UpdateQuantityButtonTest(string link)
        {
            Pages.MyCartPage.AddItemToCart(link);
            Browser.GoTo(WebLinks.CartLink);
            IList<IWebElement> inputField = Pages.MyCartPage.GetQuantityInputFields();
            for(int i=0;i<inputField.Count;i++)
            {
                IWebElement input = Pages.MyCartPage.GetQuantityInputFields()[i];
                int quantity_int = int.Parse(Pages.MyCartPage.GetValueForInputField(input));
                Pages.MyCartPage.EmptyQuantityField(input);
                Pages.MyCartPage.InsertQuantity(input, (quantity_int * 2).ToString());
                input = Pages.MyCartPage.GetQuantityInputFields()[i];
                string new_quantity = Pages.MyCartPage.GetValueForInputField(input);
                new_quantity.Should().Be((quantity_int * 2).ToString());
            }
        }

    }
}
