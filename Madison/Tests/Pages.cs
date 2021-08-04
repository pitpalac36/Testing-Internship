using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madison.Helpers;
using Madison.Pages;
using NsTestFrameworkUI.Pages;
using SeleniumExtras.PageObjects;

namespace Madison.Tests
{
    public static class Pages
    {
        public static HomePage HomePage => PageHelpers.InitPage(new HomePage());
        public static AboutUsPage AboutUsPage => PageHelpers.InitPage(new AboutUsPage());
        public static AdvancedSearchPage AdvancedSearchPage => PageHelpers.InitPage(new AdvancedSearchPage());
        public static CheckoutPage CheckoutPage => PageHelpers.InitPage(new CheckoutPage());
        public static ConnectWithUsPage ConnectWithUsPage => PageHelpers.InitPage(new ConnectWithUsPage());
        public static ContactUsPage ContactUsPage => PageHelpers.InitPage(new ContactUsPage());
        public static CustomerServicePage CustomerServicePage => PageHelpers.InitPage(new CustomerServicePage());
        public static LoginPage LoginPage => PageHelpers.InitPage(new LoginPage());
        public static MyAccountPage MyAccountPage => PageHelpers.InitPage(new MyAccountPage());
        public static MyCartPage MyCartPage => PageHelpers.InitPage(new MyCartPage());
        public static MyWishlistPage MyWishlistPage => PageHelpers.InitPage(new MyWishlistPage());
        public static OrdersAndReturnsPage OrdersAndReturnsPage => PageHelpers.InitPage(new OrdersAndReturnsPage());
        public static PrivacyPolicyPage PrivacyPolicyPage=> PageHelpers.InitPage(new PrivacyPolicyPage());
        public static ProductsPage ProductsPage => PageHelpers.InitPage(new ProductsPage());
        public static RegisterPage RegisterPage => PageHelpers.InitPage(new RegisterPage());
        public static SearchResultsPage SearchResultsPage => PageHelpers.InitPage(new SearchResultsPage());
        public static SearchTermsPage SearchTermsPage => PageHelpers.InitPage(new SearchTermsPage());
        public static SiteMapPage SiteMapPage => PageHelpers.InitPage(new SiteMapPage());

        public static ProductDetailPage ProductDetailPage => PageHelpers.InitPage(new ProductDetailPage());
        public static ShoppingCartPage ShoppingCartPage => PageHelpers.InitPage(new ShoppingCartPage());


    }
}
