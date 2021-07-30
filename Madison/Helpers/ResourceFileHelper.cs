using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    class ResourceFileHelper
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
    }
}

