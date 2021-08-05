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
    public class ProductTests : BaseTest
    {
        public static IEnumerable<object[]> GetGeneratedReviews()
        {
            yield return new object[] { Faker.Lorem.Sentence().ToString(), Faker.Lorem.Sentence().ToString(), Faker.Name.FullName().ToString() };
        }

        [TestMethod]
        [TestCategory("Product")]
        public void VerifyIfColumnsAreDisplayed()
        {
            Pages.HomePage.CheckIfProductSectionsIsVisible().Should().BeTrue();
        }

        //TODO - assert distinct elements
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
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.CheckIfHomeMainImageIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void CheckIfElectronicsPageTitleIsDisplayed()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.HomePage.CheckIfCategoryTitleIsVisible().Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        [DataRow(12)]
        public void CheckIfShowProductsDisplaysACorrectNumberOfProducts(int count)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.GetFirst12ProductsFromElectronics().Count.Should().BeLessOrEqualTo(count);
        }

        [TestMethod]
        [TestCategory("Product")]
        [DataRow("$20.00", "$400.00")]
        public void VerifyCheapestProductPrice(string firstPrice, string secondPrice)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetAscendingDirection();
            Pages.ProductsPage.GetFirstProductPrice().Should().Be(firstPrice);
            Pages.ProductsPage.GetLastProductPrice().Should().Be(secondPrice);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void CheckFirstItemPriceConsistency()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
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
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
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
        public void CheckSubmitReviewForm(string review, string summary, string nickname)
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Pages.ProductsPage.ClickOnReviews();
            Pages.ProductsPage.SetAReview(review, summary, nickname);
            Pages.ProductsPage.ClickOnSubmitReviews();
            Pages.ProductsPage.IsSuccessMessagePresent().Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Product")]
        public void VerifyRecentlyViewedProducts()
        {
            Pages.HomePage.SelectCategory("Home & Decor");
            Pages.HomePage.SelectHomeDecorSubcategory("Electronics");
            Pages.ProductsPage.SelectSortByPrice();
            Pages.ProductsPage.SetDescendingDirection();
            Pages.ProductsPage.ClickFirstProduct();
            Browser.SwitchToLastTab();
            Thread.Sleep(5000);
            // TODO
        }

        [DataTestMethod]
        [DataRow("2", "0")]
        public void checkItemIsInCart(string errorCountBefore, string errorCountAfter) {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);
            
            Pages.HomePage.SelectCategory(Constants.NavigateBar[1]);
            Pages.HomePage.SelectMenSubcategory(Constants.AllMenSections[0]);

            Pages.ProductsPage.ClickOnViewDetails();

            Pages.ProductsPage.AddToCart();
            var errorCount = Pages.ProductsPage.GetErrorListSelector().Count;
            errorCount.Should().Be(errorCountBefore.ConvertStringToInt32());

            var color = Pages.ProductsPage.SelectColor();
            Pages.ProductsPage.AddToCart();
            var errorCountNull = Pages.ProductsPage.GetErrorListSelector().Count;
            errorCountNull.Should().Be(errorCountAfter.ConvertStringToInt32());

            Pages.ShoppingCartPage.IsSuccessMessageDisplayed().Should().BeTrue();
            Pages.ShoppingCartPage.FirstItemColor().Should().Be(color);
        }
    }
}
