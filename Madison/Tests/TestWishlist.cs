using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Madison.Tests
{
    [TestClass]
    public class TestWishlist: BaseTest
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

        [TestMethod]
        public void WishlistUpdatesCorrectly()
        {
            Login();
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = Pages.MyWishlistPage.ChangeQuantity();
            Pages.MyWishlistPage.ClickOnUpdateWishlist();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }

        [TestMethod]
        public void ClickOnShareWishlistButtonRedirects()
        {
            Login();
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ClickOnShareWishlist();
            Pages.MyWishlistPage.GetUrl().Should().Contain("http://qa2.dev.evozon.com/wishlist/index/share/wishlist_id/");
            Pages.MyWishlistPage.IsShareWishlistFormDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShareWishlistFormValidatesEmptyEmail()
        {
            Login();
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ClickOnShareWishlist();
            Pages.MyWishlistPage.FillEmail("");
            Pages.MyWishlistPage.ClickOnShareWishlistButton();
            Pages.MyWishlistPage.IsRequiredValidationAdviceDisplayed().Should().BeTrue();
            Pages.MyWishlistPage.GetRequiredValidationAdvice().Should().Contain("This is a required field");
        }

        // workaround to encapsulate login into one method
        private void Login()
        {
            Pages.HomePage.ClickOnAccount();
            Pages.HomePage.ClickLogInButton();
            Pages.LoginPage.FillCredentials();
            Pages.LoginPage.LogInSubmit();
        }
    }
}
