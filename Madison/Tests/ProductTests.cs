using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NsTestFrameworkUI.Helpers;
using System.Threading;

//[assembly: Parallelize(Workers = 6, Scope = ExecutionScope.MethodLevel)]
namespace Madison.Tests
{
    [TestClass]
    public class ProductTests : MadisonTest
    {
        public static IEnumerable<object[]> GetGeneratedReviews()
        {
            yield return new object[] { Faker.Lorem.Sentence().ToString(), Faker.Lorem.Sentence().ToString(), Faker.Name.FullName().ToString() };
        }

        [TestMethod]
        [TestCategory("Product")]
        public void VerifyIfNavigationbarIsDisplayedTest()
        {
            Pages.HomePage.IsNavigationBarDisplayed().Should().BeTrue();
        }

        //TODO - assert distinct elements
        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow(6)]
        public void VerifyNavigationBarElementCountTest(int count)
        {
            Pages.HomePage.GetNavigationBarList().Count.Should().Be(count);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void VerifyIfHomeDecorMainImgIsDisplayedTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.CategoryImageIsDisplayed().Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Product")]
        public void CheckIfElectronicsPageTitleIsDisplayedTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.HomePage.CheckIfCategoryTitleIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow(12)]
        public void CheckIfShowProductsDisplaysACorrectNumberOfProductsTest(int count)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.GetFirstProductPage().Count.Should().BeLessOrEqualTo(count);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow("$20.00", "$400.00")]
        public void VerifyProductsPriceConsistency(string firstPrice, string secondPrice)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.GetFirstProductPrice().Should().Be(firstPrice);
            Pages.ProductsPage.GetLastProductPrice().Should().Be(secondPrice);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void CheckFirstItemPriceConsistencyTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.GetItemOpenedPrice().Should().Be(Pages.ProductsPage.GetFirstProductPrice());
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow("2")]
        public void AddProductToCartWithNegativeQuantityTest(string qty)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.SetProductQuantity(qty);
            Pages.ProductDetailPage.AddToCart();
            Pages.ProductDetailPage.IsAddToCartButtonVisible().Should().BeFalse(); ;
        }

        [TestMethod]
        [TestCategory("Product")]
        public void CheckIfReviewButtonIsVisibleTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            Pages.ProductsPage.IsReviewButtonPresent().Should().BeTrue(); ;
        }

        // have to refactor
        [DataTestMethod]
        [TestCategory("Product")]
        [DynamicData(nameof(GetGeneratedReviews), DynamicDataSourceType.Method)]
        public void CheckSubmitReviewFormTest(string review, string summary, string nickname)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            Pages.ProductsPage.SetReviewFields(review, summary, nickname);
            Pages.ProductsPage.ClickOnSubmitReviews();
            Pages.ProductsPage.IsSuccessMessagePresent().Should().BeTrue();
        }

        [Ignore]
        [TestCategory("Product")]
        public void VerifyRecentlyViewedProductsTest()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Browser.SwitchToLastTab();
            // TODO
        }
    }
}
