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


        [TestMethod]
        public void MyWishlistButtonIsDisplayed()
        {
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.IsWishlistButtonDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ClickOnMyWishlistButtonRedirects()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.IsRedirectedToWishlist().Should().BeTrue();
        }

        [TestMethod]
        public void WishlistItemQuantityUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = new Random().Next(100).ToString();
            Pages.MyWishlistPage.ChangeQuantity(newQuantity);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }

        [TestMethod]
        public void WishlistItemCommentUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var comment = string.Concat("comment", new Random().Next(100));
            Pages.MyWishlistPage.InsertComment(comment);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.ItemComment().Should().Be(comment);
        }

        [TestMethod]
        public void WishlistUpdatesCorrectly()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            var newQuantity = new Random().Next(100).ToString();
            Pages.MyWishlistPage.ChangeQuantity(newQuantity);
            Pages.MyWishlistPage.UpdateWishlist();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(newQuantity);
        }

        [TestMethod]
        public void ClickOnShareWishlistButtonRedirects()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ShareWishlist();
            Pages.MyWishlistPage.GetUrl().Should().Contain("http://qa2.dev.evozon.com/wishlist/index/share/wishlist_id/");
            Pages.MyWishlistPage.IsShareWishlistFormDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShareWishlistFormValidatesEmptyEmail()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
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
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(User.Usernames[0], User.Passwords[0]);
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.ClickOMyWishlist();
            Pages.MyWishlistPage.ClickOnEdit();
            var quantity = new Random().Next(100).ToString();
            Pages.MyWishlistPage.EditQuantityFromShowroom(quantity);
            Pages.MyWishlistPage.UpdateWishlistFromShowroom();
            Pages.MyWishlistPage.ItemQuantity().Should().Be(quantity);
            Pages.MyWishlistPage.IsErrorMessageDisplayed().Should().BeFalse();
        }

    }
}
