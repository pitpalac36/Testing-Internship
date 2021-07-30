﻿using FluentAssertions;
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
    public class TestCart : BaseTest
    {


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeader()
        {
            Pages.MyCartPage.GoToCart();
            WaitHelpers.WaitUntilDOcumentReady();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = "SHOPPING CART IS EMPTY";
            header.Should().Be(expected_message);
        }

        [TestMethod]
        public void EmptyCartVisibleContinueShopingLink()
        {
            Pages.MyCartPage.GoToCart();
            WaitHelpers.WaitUntilDOcumentReady();
            bool displayed = Pages.MyCartPage.ContinueShoppingLinkEmptyIsVisible();
            displayed.Should().BeTrue();
        }
        
        [TestMethod]
        public void ContinueShoppingLinkRedirectsToHomePage()
        {
            Pages.MyCartPage.GoToCart();
            WaitHelpers.WaitUntilDOcumentReady();
            string cart_url = Driver.webDriver.Url;
            Pages.MyCartPage.ClickOnContinueShoppingLinkEmptyCart();
            string redirected_url = Driver.webDriver.Url;
            redirected_url.Should().NotBe(cart_url);
            redirected_url.Should().Be("http://qa2.dev.evozon.com/");
        }

        [TestMethod]
        public void CartLabelNotDisplayedWhenCartIsEmpty()
        {
            bool visibility = Pages.MyCartPage.CartLabelVisibility();
            visibility.Should().BeFalse();
        }
    }
}
