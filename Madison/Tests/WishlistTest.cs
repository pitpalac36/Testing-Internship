using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Madison.Tests
{
    [TestClass]
    public class WishlistTest: BaseTest
    {
        [TestMethod]
        public void MyWishlistButtonIsDisplayed()
        {
            Pages.MyWishlistPage.ClickOnAccount();
            Pages.MyWishlistPage.IsWishlistButtonDisplayed().Should().BeTrue();
        }


    }
}
