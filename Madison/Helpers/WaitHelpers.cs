using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    public class WaitHelpers
    {
        public void WaitUntilDOcumentReady() {
            /*new WebDriverWait(Driver.webDriver, TimeSpan.FromSeconds(30.0))
                .Until(d => Driver.webDriver.ExecuteScript("return document.readyState").Equals("complete"));*/
        }
    }
}
