using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    class User
    {

        public static List<string> Usernames = new List<string>
        {
            "ana.ana@outlook.com",
            "clau.dia@outlook.com",
            "",
            ""

        };

        public static List<string> Passwords = new List<string>
        {
            "1234567",
            "ContNou",
            "",
            "",
        };

        public static string AlreadyExistingAccountMessage = "If you have an account with us, please log in.";
        public static List<string> AccountMenu = new List<string>
        {
            "My Account",
            "My Wishlist",
            "My Cart",
            "Checkout",
            "Register",
            "Log In",
        };
    }
}
