using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madison.Helpers;
using Madison.Pages;
using SeleniumExtras.PageObjects;

namespace Madison.Tests
{
    public static class Pages
    {
        public static HomePage HomePage => InitPage(new HomePage());
        public static AboutUsPage AboutUsPage => InitPage(new AboutUsPage());
        public static AdvancedSearchPage AdvancedSearchPage => InitPage(new AdvancedSearchPage());
        public static CheckoutPage CheckoutPage => InitPage(new CheckoutPage());
        public static ConnectWithUsPage ConnectWithUsPage => InitPage(new ConnectWithUsPage());
        public static ContactUsPage ContactUsPage => InitPage(new ContactUsPage());
        public static CustomerServicePage CustomerServicePage => InitPage(new CustomerServicePage());
        public static LoginPage LoginPage => InitPage(new LoginPage());
        public static MyAccountPage MyAccountPage => InitPage(new MyAccountPage());
        public static MyCartPage MyCartPage => InitPage(new MyCartPage());
        public static MyWishlistPage MyWishlistPage => InitPage(new MyWishlistPage());
        public static OrdersAndReturnsPage OrdersAndReturnsPage => InitPage(new OrdersAndReturnsPage());
        public static PrivacyPolicyPage PrivacyPolicyPage=> InitPage(new PrivacyPolicyPage());
        public static ProductsPage ProductsPage => InitPage(new ProductsPage());
        public static RegisterPage RegisterPage => InitPage(new RegisterPage());
        public static SearchResultsPage SearchResultsPage => InitPage(new SearchResultsPage());
        public static SearchTermsPage SearchTermsPage => InitPage(new SearchTermsPage());
        public static SiteMapPage SiteMapPage => InitPage(new SiteMapPage());

        public static T InitPage<T>(T page) {
            PageFactory.InitElements(Driver.webDriver, page);
            return page;
        }
    }
}
