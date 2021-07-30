using FluentAssertions;
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
    class TestCart : BaseTest
    {
        public void GoToCart()
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
