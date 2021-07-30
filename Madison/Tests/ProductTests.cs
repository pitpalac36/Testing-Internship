using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Tests
{
    [TestClass]
    public class ProductTests : BaseTest
    {
        [TestMethod]
        public void verifyIfColumnsAreDisplayed()
        {
            var checkVisibility = Pages.HomePage.checkIfProductSectionsIsVisible();
            Assert.IsTrue(checkVisibility);
        }

        [TestMethod]
        public void verifyHomeDecorHeaderCount()
        {
            var headerCount = Pages.HomePage.getSectionsList();
            Assert.AreEqual(6, headerCount.Count);
        }

        [TestMethod]
        public void verifyIfHomeDecorMainImgIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            var checkVisibility = Pages.HomePage.checkIfHomeMainImageIsVisible();
            Assert.IsTrue(checkVisibility);
        }

        [TestMethod]
        public void checkIfElectronicsPageTitleIsDisplayed()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var checkVisibility = Pages.HomePage.checkIfPageTitleIsVisible();
            Assert.IsTrue(checkVisibility);

        }

        [TestMethod]
        public void checkIfShowProductsDisplaysACorrectNumberOfProducts()
        {
            Pages.HomePage.goToHomeDecor();
            Pages.HomePage.goFromHomePageToElectronics();
            var products = Pages.ProductsPage.getFirst12ProductsFromElectronics();
            Assert.AreEqual(12, products.Count);
        }

        [TestMethod]
        public void verifyThatElectronicsSectionWorks()
        {

        }
        [TestMethod]
        public void checkIfThereAreProductsOnACategory()
        {

        }
        [TestMethod]
        public void checkIfAscendingSortByPriceWorks()
        {

        }

        

        [TestMethod]
        public void checkIfProductIsOpened()
        {

        }

    }
}
