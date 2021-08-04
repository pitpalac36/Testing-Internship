using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Madison.Tests
{
    [TestClass]
    public class TestWishlist: BaseTest
    {
        private static string RandomQuantity()
        {
            return Faker.RandomNumber.Next(1, 100).ToString();
        }

        private static string RandomComment()
        {
            return Faker.Lorem.Sentence();
        }

        [TestMethod]
        public void MyWishlistButtonIsDisplayed()
        {
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.IsWishlistButtonDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ClickOnMyWishlistButtonRedirects()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.IsRedirectedToWishlist().Should().BeTrue();
        }

        [TestMethod]
        public void WishlistItemQuantityUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = RandomQuantity();
            Pages.MyWishlistPage.ChangeQuantity(newQuantity);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }

        [TestMethod]
        public void WishlistItemCommentUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var comment = RandomComment();
            Pages.MyWishlistPage.InsertComment(comment);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.ItemComment().Should().Be(comment);
        }

        [TestMethod]
        public void WishlistUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = RandomQuantity();
            Pages.MyWishlistPage.ChangeQuantity(newQuantity);
            Pages.MyWishlistPage.UpdateWishlist();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }

        [TestMethod]
        public void ClickOnShareWishlistButtonRedirects()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ShareWishlist();
            Pages.MyWishlistPage.GetUrl().Should().Contain("http://qa2.dev.evozon.com/wishlist/index/share/wishlist_id/");
            Pages.MyWishlistPage.IsShareWishlistFormDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShareWishlistFormValidatesEmptyEmail()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ShareWishlist();
            Pages.MyWishlistPage.FillEmail("");
            Pages.MyWishlistPage.ShareWishlistFinal();
            Pages.MyWishlistPage.IsRequiredValidationAdviceDisplayed().Should().BeTrue();
            Pages.MyWishlistPage.GetRequiredValidationAdvice().Should().Contain("This is a required field");
        }

        [TestMethod]
        public void UpdateWishlistFromShowroom()
        {
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ClickOnEdit();
            var quantity = RandomQuantity();
            Pages.MyWishlistPage.EditQuantityFromShowroom(quantity);
            Pages.MyWishlistPage.UpdateWishlistFromShowroom();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(quantity);
            Pages.MyWishlistPage.IsErrorMessageDisplayed().Should().BeFalse();
        }

    }
}
