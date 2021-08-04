using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NsTestFrameworkUI;
using NsTestFrameworkUI.Helpers;

[assembly: Parallelize(Workers = 6, Scope = ExecutionScope.MethodLevel)]
namespace Madison.Tests
{
    [TestClass]
    public class ProductTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Product")]
        public void verifyIfColumnsAreDisplayed()
        {
            var checkVisibility = Pages.HomePage.checkIfProductSectionsIsVisible();
            checkVisibility.Should().BeTrue();
        }

        [DataRow(6)]
        [DataTestMethod]
        [TestCategory("Product")]          
                
        public void verifyHomeDecorHeaderCount(int count)
        {
            var headerCount = Pages.HomePage.getSectionsList();
            headerCount.Count.Should().Be(count);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void verifyIfHomeDecorMainImgIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            var checkVisibility = Pages.HomePage.checkIfHomeMainImageIsVisible();
            checkVisibility.Should().BeTrue();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void checkIfElectronicsPageTitleIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var checkVisibility = Pages.HomePage.checkIfPageTitleIsVisible();
            checkVisibility.Should().BeTrue();
        }

        [DataRow(12)]
        [DataTestMethod]
        [TestCategory("Product")]
        public void checkIfShowProductsDisplaysACorrectNumberOfProducts(int count)
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var products = Pages.ProductsPage.getFirst12ProductsFromElectronics();
            products.Count.Should().BeLessOrEqualTo(count);
        }

        [DataRow("$20.00", "$400.00")]
        [TestMethod]
        [TestCategory("Product")]
        public void verifyCheapestProductPrice(string firstPrice, string secondPrice)
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setAscendingDirection();
            var cheapItem = Pages.ProductsPage.getFirstProductPrice();
            var expensiveItem = Pages.ProductsPage.getLastProductPrice();
            cheapItem.Should().Be(firstPrice);
            expensiveItem.Should().Be(secondPrice);
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void checkFirstItemPriceConsistency()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setAscendingDirection();
            var expectedPrice = Pages.ProductsPage.getFirstProductPrice();
            Pages.ProductsPage.clickFirstProduct();
            var actualPrice = Pages.ProductsPage.getItemOpenedPrice();
            actualPrice.Should().Be(expectedPrice);
        }

        [DataRow("2")]
        [DataTestMethod]
        [TestCategory("Product")]
        public void addNegativeQuantityForProduct(string qty)
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setAscendingDirection();
            Pages.ProductsPage.clickFirstProduct();
            Pages.ProductsPage.setProductQuantity(qty);
            Pages.ProductsPage.AddToCart();
            var visibility = Pages.ProductsPage.isAddToCartButtonVisible();
            visibility.Should().BeFalse();
        }

        [DataTestMethod]
        [TestCategory("Product")]
        public void checkIfReviewButtonIsVisible()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setDescendingDirection();
            Pages.ProductsPage.clickFirstProduct();
            Pages.ProductsPage.clickOnReviews();
            var visibility = Pages.ProductsPage.isReviewButtonPresent();
            visibility.Should().BeTrue();

        }

        [DataRow("nice", "good product", "georgel de pe coclauri")]
        [DataTestMethod]
        [TestCategory("Product")]
        public void checkSubmitReviewForm(string review, string summary, string nickname)
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setDescendingDirection();
            Pages.ProductsPage.clickFirstProduct();
            Pages.ProductsPage.clickOnReviews();
            Pages.ProductsPage.setReview(review);
            Pages.ProductsPage.setSummary(summary);
            Pages.ProductsPage.setNickname(nickname);
            Pages.ProductsPage.clickOnSubmitReviews();
            var visibility = Pages.ProductsPage.isSuccessMessagePresent();
            visibility.Should().BeTrue();

        }

        [Ignore]
        [TestCategory("Product")]
        public void verifyRecentlyViewedProducts() {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setDescendingDirection();
            Pages.ProductsPage.clickFirstProduct();
            Browser.SwitchToLastTab();
            // TODO
        }

        [DataTestMethod]
        [DataRow("2", "0")]
        public void SecondFlow(string errorCountBefore, string errorCountAfter) {
            //1. TODO Login
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[5]);
            Pages.LoginPage.Login(Constants.Usernames[0], Constants.Passwords[0]);

            // Empty cart
            Pages.HomePage.ClickOnAccount();
            Pages.HomePage.GoToCart();
            Pages.MyCartPage.ClickOnEmptyCartButton();

            //2. Access Men - New Arrivals section
            Pages.HomePage.goToMenSection();
            Pages.HomePage.goToMenNewArrivals();

            //3. Open product details page(of first item)
            Pages.ProductsPage.clickOnViewDetails();

            //4. Check error messages from product details page when adding an item to cart
            Pages.ProductsPage.AddToCart();
            var errorCount1 = Pages.ProductsPage.GetErrorListSelector().Count;
            Assert.AreEqual(errorCount1, errorCountBefore.ConvertStringToInt32());

            // 5. Add item to cart
            var color = Pages.ProductsPage.selectColor();
            var size = Pages.ProductsPage.selectSize();
            Pages.ProductsPage.AddToCart();
            var errorCount2 = Pages.ProductsPage.GetErrorListSelector().Count;
            Assert.AreEqual(errorCount2, errorCountAfter.ConvertStringToInt32());

            //6. Check item is in cart
            Pages.ShoppingCartPage.IsSuccessMessageDisplayed().Should().BeTrue();
            Pages.ShoppingCartPage.FirstItemColor().Should().Be(color);
            //Pages.ShoppingCartPage.FirstItemSize().Should().Be(size);
        }
    }
}
