using Madison.Pages;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;

namespace Madison.Tests
{
    public static class Pages
    {
        public static NavigationPage NavigationPage => PageHelpers.InitPage(new NavigationPage());
        public static HomePage HomePage => PageHelpers.InitPage(new HomePage());
        public static LoginPage LoginPage => PageHelpers.InitPage(new LoginPage());
        public static MyAccountPage MyAccountPage => PageHelpers.InitPage(new MyAccountPage());
        public static MyCartPage MyCartPage => PageHelpers.InitPage(new MyCartPage());
        public static MyWishlistPage MyWishlistPage => PageHelpers.InitPage(new MyWishlistPage());
        public static ProductsPage ProductsPage => PageHelpers.InitPage(new ProductsPage());
        public static RegisterPage RegisterPage => PageHelpers.InitPage(new RegisterPage());
        public static ProductDetailPage ProductDetailPage => PageHelpers.InitPage(new ProductDetailPage());

        public static CheckoutPage CheckoutPage => PageHelpers.InitPage(new CheckoutPage());
        public static string GetUrl()
        {
            return Browser.WebDriver.Url;
        }
    }
}
