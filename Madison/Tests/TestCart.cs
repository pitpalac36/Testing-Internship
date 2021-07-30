using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Madison.Tests
{
    [TestClass]
    class TestCart : BaseTest
    {
        
        public static void GoToCart()
        {
            Driver.webDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/checkout/cart/");
        }


        [TestMethod]
        public void EmptyCartShowsEmptyCartHeader()
        {
            GoToCart();
            WaitHelpers.WaitUntilDOcumentReady();
            string header = Pages.MyCartPage.GetHeaderMessage();
            string expected_message = "SHOPPING CART IS EMPTY";
            header.Should().Be(expected_message);
        }
    }
}
