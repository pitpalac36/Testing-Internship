using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NsTestFrameworkUI.Helpers;

//[assembly: Parallelize(Workers = 6, Scope = ExecutionScope.MethodLevel)]
namespace Madison.Tests
{
    [TestClass]
    public class ProductTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Product")]
        public void VerifyIfColumnsAreDisplayed()
        {
            Pages.HomePage.CheckIfProductSectionsIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow(6)]
        public void VerifyHomeDecorHeaderCount(int count)
        {
            Pages.HomePage.GetSectionsList().Count.Should().Be(count);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void VerifyIfHomeDecorMainImgIsDisplayed()
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.CheckIfHomeMainImageIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void CheckIfElectronicsPageTitleIsDisplayed()
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.HomePage.CheckIfPageTitleIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow(12)]
        public void CheckIfShowProductsDisplaysACorrectNumberOfProducts(int count)
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.GetFirst12ProductsFromElectronics().Count.Should().BeLessOrEqualTo(count);
        }

        [TestMethod]
        [TestCategory("Product")]
        [DataRow("$20.00", "$400.00")]
        public void VerifyCheapestProductPrice(string firstPrice, string secondPrice)
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.GetFirstProductPrice().Should().Be(firstPrice);
            Pages.ProductsPage.GetLastProductPrice().Should().Be(secondPrice);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void CheckFirstItemPriceConsistency()
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            var expectedPrice = Pages.ProductsPage.GetFirstProductPrice();
            Pages.ProductsPage.ClickFirstProduct();
            var actualPrice = Pages.ProductsPage.GetItemOpenedPrice();
            actualPrice.Should().Be(expectedPrice);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow("2")]
        public void AddNegativeQuantityForProduct(string qty)
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.SetProductQuantity(qty);
            Pages.ProductsPage.AddToCart();
            Pages.ProductsPage.IsAddToCartButtonVisible().Should().BeFalse(); ;
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void CheckIfReviewButtonIsVisible()
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            Pages.ProductsPage.IsReviewButtonPresent().Should().BeTrue(); ;
        }
        public static IEnumerable<object[]> GetGeneratedReviews()
        {
            yield return new object[] { Faker.Lorem.Words(4).ToString(), Faker.Lorem.Sentence().ToString(), Faker.Name.FullName().ToString() };
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DynamicData(nameof(GetGeneratedReviews), DynamicDataSourceType.Method)]
        public void CheckSubmitReviewForm(string review, string summary, string nickname)
        {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            Pages.ProductsPage.SetReview(review);
            Pages.ProductsPage.SetSummary(summary);
            Pages.ProductsPage.SetNickname(nickname);
            Pages.ProductsPage.ClickOnSubmitReviews();
            Pages.ProductsPage.IsSuccessMessagePresent().Should().BeTrue();

        }

        [Ignore]
        [TestCategory("Product")]
        public void VerifyRecentlyViewedProducts() {
            Pages.HomePage.GoToHomeDecor();
            Pages.HomePage.GoFromHomePageToElectronics();
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Browser.SwitchToLastTab();
            // TODO
        }

        [DataTestMethod]
        [DataRow("2", "0")]
        public void SecondFlow(string errorCountBefore, string errorCountAfter) {
            //1. TODO Login
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);

            // Empty cart - Needs refactoring
            //Pages.HomePage.ClickOnAccount();
            //Pages.HomePage.GoToCart();
            //Pages.MyCartPage.ClickOnEmptyCartButton();
            
            //2. Access Men - New Arrivals section
            Pages.HomePage.SelectMenCategory(Constants.NavigateBar[1]);
            Pages.HomePage.SelectMenSubcategory(Constants.AllMenSection[0]);

            //3. Open product details page(of first item)
            Pages.ProductsPage.ClickOnViewDetails();

            //4. Check error messages from product details page when adding an item to cart
            Pages.ProductsPage.AddToCart();
            var errorCount = Pages.ProductsPage.GetErrorListSelector().Count;
            errorCount.Should().Be(errorCountBefore.ConvertStringToInt32());

            // 5. Add item to cart
            var color = Pages.ProductsPage.SelectColor();
            var size = Pages.ProductsPage.SelectSize();
            Pages.ProductsPage.AddToCart();
            var errorCountNull = Pages.ProductsPage.GetErrorListSelector().Count;
            errorCountNull.Should().Be(errorCountAfter.ConvertStringToInt32());

            //6. Check item is in cart
            Pages.ShoppingCartPage.IsSuccessMessageDisplayed().Should().BeTrue();
            Pages.ShoppingCartPage.FirstItemColor().Should().Be(color);
            //Pages.ShoppingCartPage.FirstItemSize().Should().Be(size);
        }
    }
}
