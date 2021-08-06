using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace Madison.Pages
{
    public class MagentoHomePage
    {
        public static By _navigationBarList = By.CssSelector("#nav > li");
        private readonly By _popupCloseSelector = By.CssSelector(".message-popup-head a");

        public void ClickOnClosePopup()
        {
            _popupCloseSelector.ActionClick();
        }

        public void SelectCategory(string category)
        {
            var categorySection = _navigationBarList.GetElements().First(item => item.Text.ToLower() == category.ToLower());
            Actions action = new Actions(Browser.WebDriver);
            action.MoveToElement(categorySection).Perform();
        }


    }
}