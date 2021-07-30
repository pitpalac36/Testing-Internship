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
        public void checkIfHomeDecorDropdownIsActive()
        {

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
        public void checkIfShowProductsDisplaysACorrectNumberOfProducts()
        {

        }

        [TestMethod]
        public void checkIfProductIsOpened() {
        
        }

    }
}
