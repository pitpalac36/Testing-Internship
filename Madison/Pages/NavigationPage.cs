using NsTestFrameworkUI.Helpers;

namespace Madison.Pages
{
    public class NavigationPage
    {
        public void GoToWishlist()
        {
            Browser.GoTo(WebLinks.My_Wishlist_Page);
        }

    }
}
