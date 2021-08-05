using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Madison.Tests
{
    [TestClass]
    public class TestWishlist: BaseTest
    {

        private static IEnumerable<object[]> GetQuantity()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new object[] { Faker.RandomNumber.Next(1, 100).ToString() };
            }
        }

        private static IEnumerable<object[]> GetComment()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new object[] { Faker.Lorem.Sentence() };
            }
        }

        [TestMethod]
        public void MyWishlistButtonIsDisplayedTest()
        {
            Pages.HomePage.ClickOnAccount();
            Pages.MyWishlistPage.IsWishlistButtonDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ClickOnMyWishlistButtonRedirectsTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.IsRedirectedToWishlist().Should().BeTrue();
        }

        [DataTestMethod]
        [DoNotParallelize]
        [DynamicData(nameof(GetQuantity), DynamicDataSourceType.Method)]
        public void WishlistItemQuantityUpdatesCorrectlyTest(string quantity)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ChangeQuantity(quantity);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.GetItemQuantity().Should().Be(quantity);
        }

        [DataTestMethod]
        [DoNotParallelize]
        [DynamicData(nameof(GetComment), DynamicDataSourceType.Method)]
        public void WishlistItemCommentUpdatesCorrectlyTest(string comment)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.InsertComment(comment);
            Pages.MyWishlistPage.UpdateItem();
            Pages.MyWishlistPage.GetItemComment().Should().Be(comment);
        }

        [DataTestMethod]
        [DoNotParallelize]
        [DynamicData(nameof(GetQuantity), DynamicDataSourceType.Method)]
        public void WishlistUpdatesCorrectlyTest(string quantity)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ChangeQuantity(quantity);
            Pages.MyWishlistPage.UpdateWishlist();
            Pages.MyWishlistPage.GetItemQuantity().Should().Be(quantity);
        }

        [TestMethod]
        public void ClickOnShareWishlistButtonRedirectsTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ShareWishlist();
            string expectedUrl = WebLinks.ShareWishlist;
            BrowserHelper.GetCurrentUrl().Should().Contain(expectedUrl);
            Pages.MyWishlistPage.IsShareWishlistFormDisplayed().Should().BeTrue();
        }

        [DataTestMethod]
        [DoNotParallelize]
        [DataRow("", "This is a required field")]
        public void ShareWishlistFormValidatesEmptyEmailTest(string email, string expectedMessage)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ShareWishlist();
            Pages.MyWishlistPage.FillEmail(email);
            Pages.MyWishlistPage.ShareWishlistFinal();
            Pages.MyWishlistPage.IsRequiredValidationAdviceDisplayed().Should().BeTrue();
            Pages.MyWishlistPage.GetRequiredValidationAdvice().Should().Contain(expectedMessage);
        }

        [DataTestMethod]
        [DoNotParallelize]
        [DataRow("lorem", "Please enter a valid email addresses")]
        public void ShareWishlistFormValidatesBadEmailTest(string email, string expectedMessage)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ShareWishlist();
            Pages.MyWishlistPage.FillEmail(email);
            Pages.MyWishlistPage.ShareWishlistFinal();
            Pages.MyWishlistPage.IsRequiredValidationAdviceDisplayed().Should().BeTrue();
            Pages.MyWishlistPage.GetRequiredValidationAdvice().Should().Contain(expectedMessage);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetQuantity), DynamicDataSourceType.Method)]
        public void UpdateWishlistFromProductsDetailsPageTest(string quantity)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            Pages.HomePage.SelectMyAccountMenu(Menu.MyWishlist.GetDescription());
            Pages.MyWishlistPage.ClickOnEdit();
            Pages.ProductDetailPage.EditWishlistItemQuantity(quantity);
            Pages.ProductDetailPage.UpdateWishlist();
            Pages.MyWishlistPage.GetItemQuantity().Should().Be(quantity);
            Pages.MyWishlistPage.IsErrorMessageDisplayed().Should().BeFalse();
        }

    }
}
