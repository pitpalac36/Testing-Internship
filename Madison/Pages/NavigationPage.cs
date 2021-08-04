using Madison.Helpers;
using NsTestFrameworkUI.Helpers;

namespace Madison.Pages
{
    public class NavigationPage
    {
        public void GoToWishlist()
        {
            Browser.GoTo(ResourceFileHelper.GetValueAssociatedToString("My Wishlist Page"));
        }

    }
}
