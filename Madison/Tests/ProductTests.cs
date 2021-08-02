using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[assembly: Parallelize(Workers = 6, Scope = ExecutionScope.MethodLevel)]
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

        [TestMethod]
        [TestCategory("Product")]          
                
        public void verifyHomeDecorHeaderCount()
        {
            var headerCount = Pages.HomePage.getSectionsList();
            headerCount.Count.Should().Be(6);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void verifyIfHomeDecorMainImgIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            var checkVisibility = Pages.HomePage.checkIfHomeMainImageIsVisible();
            checkVisibility.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Product")]
        public void checkIfElectronicsPageTitleIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var checkVisibility = Pages.HomePage.checkIfPageTitleIsVisible();
            checkVisibility.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Product")]
        public void checkIfShowProductsDisplaysACorrectNumberOfProducts()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var products = Pages.ProductsPage.getFirst12ProductsFromElectronics();
            products.Count.Should().Be(12);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void verifyCheapestProductPrice()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            Pages.ProductsPage.selectSortByPrice();
            Pages.ProductsPage.setAscendingDirection();
            var cheapItem = Pages.ProductsPage.getFirstProductPrice();
            var expensiveItem = Pages.ProductsPage.getLastProductPrice();
            cheapItem.Should().Be("$20.00");
            expensiveItem.Should().Be("$400.00");
        }

    }
}
