using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    public enum Menu
    {
        [Description("My Account")] MyAccount,
        [Description("My Wishlist")] MyWishlits,
        [Description("My Cart")] MyCart,
        [Description("Checkout")] Checkout,
        [Description("Register")] Register,
        [Description("Log In")] Login,

    }
     public static class ResourceFileHelper
    {
        private static ResourceManager rm;

        static ResourceFileHelper()
        {
            rm = new ResourceManager("Madison.WebLinks", Assembly.GetExecutingAssembly());
        }
        public static string GetValueAssociatedToString(string search)
        {
            return rm.GetString(search);
        }

        public static string GetDescription(this Menu menu)
        {
            var fieldInfo = menu.GetType().GetField(menu.ToString());
            if (fieldInfo == null) return string.Empty;

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes[0].Description;
        }
    }
}

