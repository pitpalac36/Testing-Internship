using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Madison.Tests
{

    [TestClass]
    public class MagentoTest : BaseTest
    {

        public static IEnumerable<object[]> GetCredentials()
        {
            yield return new object[] { Constants.Usernames[0], Constants.Passwords[0] };
            yield return new object[] { Constants.Usernames[1], Constants.Passwords[1] };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCredentials), DynamicDataSourceType.Method)]
        public void VerifyReviewAppearsOnProductTest(string username, string password)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(username,password);
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            
        }

    }
}