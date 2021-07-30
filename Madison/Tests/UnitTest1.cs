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
           string title= driver.Title;
            return title;
        }


        public void SelectMyAccountMenu(string accountMenu)
        {
            IWebElement accountElement = driver.FindElement(By.CssSelector(".account-cart-wrapper > a"));
            accountElement.Click();
            IList<IWebElement> menuElements = driver.FindElements(By.CssSelector("#header-account>.links>ul li"));
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
            driver.Navigate().Back();
            SelectMyAccountMenu("My Wishlist");
            driver.Navigate().Back();
            SelectMyAccountMenu("My Cart");
            driver.Navigate().Back();
            SelectMyAccountMenu("Checkout");
            driver.Navigate().Back();
            SelectMyAccountMenu("Register");
            driver.Navigate().Back();
            SelectMyAccountMenu("Log In");
            driver.Navigate().Back();
            
            /*SelectMyAccountMenu(MyAccountMenu.MyAccount);
            SelectMyAccountMenu(MyAccountMenu.MyWishlist);
            SelectMyAccountMenu(MyAccountMenu.MyCart);
            SelectMyAccountMenu(MyAccountMenu.Checkout);
            SelectMyAccountMenu(MyAccountMenu.Register);
            SelectMyAccountMenu(MyAccountMenu.Login);*/
        }

    }
}
