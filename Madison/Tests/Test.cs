using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UnitDemo
{
    [TestClass]
    public class Test: BaseTest
    {

        public static void GoToSite(string url)
        {
            Driver.webDriver.Navigate().GoToUrl(url);
        }

        public static string GetTitle()
        {
            return Driver.webDriver.Title;
        }

        public static string GetCurrentUrl()
        {
            return Driver.webDriver.Url;
        }

        public static IWebElement GetLogo()
        {
            return Driver.webDriver.FindElement(By.CssSelector(".logo img.large"));
        }

        public static void ClickOnLogo()
        {
            var logo = Driver.webDriver.FindElement(By.CssSelector(".logo img.large"));
            logo.Click();
        }

        public static void ClickOnAccount()
        {
            var accountBtn = Driver.webDriver.FindElement(By.CssSelector(".account-cart-wrapper span+span"));
            accountBtn.Click();
            //Thread.Sleep(3000);
        }

        public static void ClickOnItem()
        {
            var item = Driver.webDriver.FindElement(By.CssSelector("ul .item.last:nth-child(2) img"));
            item.Click();
        }

        public static void ClickOnSkirt()
        {
            var skirt = Driver.webDriver.FindElement(By.CssSelector(".item.last img"));
            skirt.Click();
        }

        public static void ClickOnLogin()
        {
            var loginBtn = Driver.webDriver.FindElement(By.Id("send2"));
            loginBtn.Submit();
        }

        public static void ClickOnSearch()
        {
            var searchBtn = Driver.webDriver.FindElement(By.CssSelector("button[title='Search']"));
            searchBtn.Click();
        }

        public static void ClickOnWishList()
        {
            var wishlistBtn = Driver.webDriver.FindElement(By.CssSelector("a[title^='My Wishlist']"));
            wishlistBtn.Click();
        }

        public static void ClickOnAddToWishList()
        {
            var wishListButton = Driver.webDriver.FindElement(By.CssSelector("a.link-wishlist"));
            wishListButton.Click();
        }

        public static void ClickOnUpdateWishList()
        {
            var updateBtn = Driver.webDriver.FindElement(By.CssSelector("button[type='submit'],[title='Update Wishlist']"));
            updateBtn.Click();
        }

        private static void NavigateToWomen()
        {
            var button = Driver.webDriver.FindElement(By.CssSelector(".nav-primary li"));
            button.Click();
        }

        public static void NavigateBack()
        {
            Driver.webDriver.Navigate().Back();
        }

        public static void NavigateForward()
        {
            Driver.webDriver.Navigate().Forward();
        }

        public static void NavigateSale()
        {
            var vip = Driver.webDriver.FindElement(By.CssSelector("a.level0:last-child"));
            System.Diagnostics.Debug.WriteLine(vip.Text);
            vip.Click();
        }

        public static void NavigateLogin()
        {
            var login = Driver.webDriver.FindElement(By.CssSelector(".links li.last a[title='Log In']"));
            login.Click();
        }

        public static void Refresh()
        {
            Driver.webDriver.Navigate().Refresh();
        }

        public static void ListNewProducts()
        {
            var list = Driver.webDriver.FindElement(By.CssSelector(".widget-products"));
            var children = list.FindElements(By.XPath("./child::*"));
            System.Diagnostics.Debug.WriteLine(children.Count);
            foreach (var each in children)
            {
                System.Diagnostics.Debug.WriteLine(each.Text);
            }
        }

        public static void FillEmail()
        {
            var email = Driver.webDriver.FindElement(By.Name("login[username]"));
            email.SendKeys("ana.ana@outlook.com");
        }

        public static void FillPassword()
        {
            var password = Driver.webDriver.FindElement(By.Name("login[password]"));
            password.SendKeys("1234567");
        }

        public static void FillCredentials()
        {
            FillEmail();
            FillPassword();
        }

        public static void FillSearchBar()
        {
            var searchBar = Driver.webDriver.FindElement(By.CssSelector("#search"));
            searchBar.SendKeys("skirts");
        }

        public static void Search()
        {
            FillSearchBar();
            ClickOnSearch();
        }

        public static void EditQuantity()
        {
            var quantityInput = Driver.webDriver.FindElement(By.CssSelector(".add-to-cart-alt input"));
            var newQuantity = int.Parse(quantityInput.GetAttribute("value")) * 2;
            quantityInput.Clear();
            quantityInput.SendKeys(newQuantity.ToString());
            //Thread.Sleep(5000);
        }

              public static void DoLoginFlow()
        {
            // click on account
            ClickOnAccount();

            // go to login
            NavigateLogin();

            // fill in credentials
            FillCredentials();

            // click on login
            ClickOnLogin();
        }

        [TestMethod]
        public void TestHomePage()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com");
            Assert.AreEqual("http://qa2.dev.evozon.com/", Driver.webDriver.Url);

            // get title
            System.Diagnostics.Debug.WriteLine(GetTitle());

            // get current url
            System.Diagnostics.Debug.WriteLine(GetCurrentUrl());

            // click on logo
            ClickOnLogo();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/");

            // navigate to women page
            NavigateToWomen();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/women.html");

            // navigate back
            NavigateBack();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/");

            // navigate forward
            NavigateForward();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/women.html");

            // refresh
            Refresh();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/women.html");
        }

        [TestMethod]
        public void TestAccount()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // click on account button
            ClickOnAccount();
            var dropDownContainer = Driver.webDriver.FindElement(By.CssSelector("div#header-account"));
            Assert.IsTrue(dropDownContainer.Displayed);

        }

        [TestMethod]
        public void TestNewProductsList()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // list the number of new products
            ListNewProducts();

        }

        [TestMethod]
        public void TestNavigation()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // get the navigation headlines
            NavigateSale();
            var categoryHeader = Driver.webDriver.FindElement(By.CssSelector(".page-title.category-title h1"));
            Assert.AreEqual(categoryHeader.Text, "VIP");

            // click on item
            ClickOnItem();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/vip/rolls-travel-wallet.html");
            var infoContainer = Driver.webDriver.FindElement(By.ClassName("product-essential"));
            Assert.IsTrue(infoContainer.Displayed);

        }

        [TestMethod]
        public void Login()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // click on account
            ClickOnAccount();

            // go to login
            NavigateLogin();
            Assert.AreEqual(Driver.webDriver.Url, "http://qa2.dev.evozon.com/customer/account/login/");
            var form = Driver.webDriver.FindElement(By.CssSelector("form#login-form"));
            form.Displayed.Should().BeTrue();

            // fill in credentials
            FillCredentials();

            // click on login
            ClickOnLogin();
        }

        [TestMethod]
        public void AddToWishList()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // login steps (click on account, fill in credentials etc)
            DoLoginFlow();

            // search
            Search();

            // click on first item
            ClickOnSkirt();

            // click on add to wishlist
            ClickOnAddToWishList();

        }

        [TestMethod]
        public void EditWishList()
        {

            // go to Maddison
            GoToSite("http://qa2.dev.evozon.com/");

            // login steps (click on account, fill in credentials etc)
            DoLoginFlow();

            // click on account
            ClickOnAccount();

            // click on my wishlist
            ClickOnWishList();

            // edit quantity for item in wishlist
            EditQuantity();

            // click on update wishlist button
            ClickOnUpdateWishList();

        }

    }
}
