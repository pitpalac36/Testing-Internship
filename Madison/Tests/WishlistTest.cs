using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Madison.Tests
{
    [TestClass]
    public class WishlistTest: BaseTest
    {


        [TestMethod]
        public void MyWishlistButtonIsDisplayed()
        {
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.IsWishlistButtonDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ClickOnMyWishlistButtonRedirects()
        {
            Login();
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.IsRedirectedToWishlist().Should().BeTrue();
        }

        [TestMethod]
        public void WishlistItemQuantityUpdatesCorrectly()
        {
            Login();
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = Pages.MyWishlistPage.ChangeQuantity();
            Pages.MyWishlistPage.ClickOnUpdateItem();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }




        public void Login()
        {

            // go to Maddison
            Driver.webDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");

            // click on account
            Pages.MyWishlistPage.ClickOnAccount();

            // go to login
            var login = Driver.webDriver.FindElement(By.CssSelector(".links li.last a[title='Log In']"));
            login.Click();

            var form = Driver.webDriver.FindElement(By.CssSelector("form#login-form"));
            form.Displayed.Should().BeTrue();

            var email = Driver.webDriver.FindElement(By.Name("login[username]"));
            email.SendKeys("ana.ana@outlook.com");
            var password = Driver.webDriver.FindElement(By.Name("login[password]"));
            password.SendKeys("1234567");

            var loginBtn = Driver.webDriver.FindElement(By.Id("send2"));
            loginBtn.Submit();
        }
    }
}
