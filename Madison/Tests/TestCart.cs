﻿using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
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


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeader()
        {
            Pages.MyCartPage.GoToCart();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [TestMethod]
        public void EmptyCartVisibleContinueShopingLink()
        {
            Pages.MyCartPage.GoToCart();
            bool displayed = Pages.MyCartPage.ContinueShoppingLinkEmptyIsVisible();
            displayed.Should().BeTrue();
        }

        [TestMethod]
        public void CartTableNotVisibleEmpty()
        {
            Pages.MyCartPage.GoToCart();
            bool displayed = Pages.MyCartPage.ItemTableVisibility();
            displayed.Should().BeFalse();

            
        }

        [TestMethod]
        public void CartCheckoutFormNotVisibleWhenEmpty()
        {
            Pages.MyCartPage.GoToCart();
            bool displayed = Pages.MyCartPage.CheckoutFormVisibility();
            displayed.Should().BeFalse();
            
        }
        
        [TestMethod]
        public void ContinueShoppingLinkRedirectsToHomePage()
        {
            string homepageUrl = ResourceFileHelper.GetValueAssociatedToString("Homepage");
            Pages.MyCartPage.GoToCart();
            string cart_url = Browser.WebDriver.Url;
            Pages.MyCartPage.ClickOnContinueShoppingLinkEmptyCart();
            string redirected_url = Browser.WebDriver.Url;
            redirected_url.Should().NotBe(cart_url);
            redirected_url.Should().Be(homepageUrl);
        }

        [TestMethod]
        public void CartLabelNotDisplayedWhenCartIsEmpty()
        {
            Pages.MyCartPage.GoToCart();
            bool visibility = Pages.MyCartPage.CartLabelVisibility();
            visibility.Should().BeFalse();
        }

        [TestMethod]
        public void CartLabelDisplayedWithItemsInCart()
        {
            Pages.MyCartPage.AddItemToCart();
            bool visibility = Pages.MyCartPage.CartLabelVisibility();
            visibility.Should().BeTrue();
        }

        [TestMethod]
        public void EmptyCartButtonDeletesCartElements()
        {
            Pages.MyCartPage.AddItemToCart();
            Pages.MyCartPage.ClickOnEmptyCartButton();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = ResourceFileHelper.GetValueAssociatedToString("EmptyCartMessage");
            header.Should().Be(expected_message);
        }

        [TestMethod]
        public void CheckMatchingSubtotals()
        {
            Pages.MyCartPage.AddItemToCart();
            Pages.MyCartPage.GoToCart();
            float subtotalSum = Pages.MyCartPage.GetSubtotalItemsPrice();
            float subtotal = Pages.MyCartPage.GetSubtotalLabelPrice();
            subtotal.Should().Be(subtotalSum);
        }

    }
}
