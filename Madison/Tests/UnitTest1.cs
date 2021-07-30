using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1: BaseTest
    {        

        public string  GetTitle()
        {
           string title= Driver.webDriver.Title;
            return title;
        }


        public void SelectMyAccountMenu(string accountMenu)
        {
            IWebElement accountElement = Driver.webDriver.FindElement(By.CssSelector(".account-cart-wrapper > a"));
            accountElement.Click();
            IList<IWebElement> menuElements = Driver.webDriver.FindElements(By.CssSelector("#header-account>.links>ul li"));
            menuElements.First(item => item.Text == accountMenu).Click();

        }


        [TestMethod]
        public void TestMethod_Title()
        {
            GetTitle().Should().Be("Madison Island");
        }


        [TestMethod]
        public void TestMethod_AccountMenu()
        {
            SelectMyAccountMenu("My Account");
            Driver.webDriver.Navigate().Back();
            SelectMyAccountMenu("My Wishlist");
            Driver.webDriver.Navigate().Back();
            SelectMyAccountMenu("My Cart");
            Driver.webDriver.Navigate().Back();
            SelectMyAccountMenu("Checkout");
            Driver.webDriver.Navigate().Back();
            SelectMyAccountMenu("Register");
            Driver.webDriver.Navigate().Back();
            SelectMyAccountMenu("Log In");
            Driver.webDriver.Navigate().Back();
            
            /*SelectMyAccountMenu(MyAccountMenu.MyAccount);
            SelectMyAccountMenu(MyAccountMenu.MyWishlist);
            SelectMyAccountMenu(MyAccountMenu.MyCart);
            SelectMyAccountMenu(MyAccountMenu.Checkout);
            SelectMyAccountMenu(MyAccountMenu.Register);
            SelectMyAccountMenu(MyAccountMenu.Login);*/
        }

    }
}
