using FluentAssertions;
using Madison.Helpers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//[assembly: Parallelize(Workers =4,Scope =ExecutionScope.MethodLevel)]

namespace Madison.Tests
{

    [TestClass]
    public class LoginTest : BaseTest
    {
        public static IEnumerable<object[]> GetCredentials()
        {
            yield return new object[] { Constants.Usernames[0], Constants.Passwords[0],"WELCOME, ANA ANA!" };
            yield return new object[] { Constants.Usernames[1], Constants.Passwords[1],"WELCOME, CLAU DIA!" };

        }

        [DataTestMethod]
        [DynamicData(nameof(GetCredentials), DynamicDataSourceType.Method)]
        [TestCategory ("Login")]
        public void LoginAction(string username, string password, string expectedWelcomeMessage)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login(username, password);
            Pages.MyAccountPage.GetWelcomeMessage().Should().Be(expectedWelcomeMessage);
        }

        [TestMethod]
        public void AlreadyRegisteredTxtDisplayed()
        {
           
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.GetAlreadyRegisteredMessage().Should().Be(Messages.Registered); 
        }

        [DoNotParallelize]
        [TestMethod]
        public void ExistingAccount()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.GetExistingAccountMessage().Should().Be(Messages.Existing_Account);
        }

        [TestMethod]
        public void CreateAnAccount()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.ClickCreateAccount();

            Pages.LoginPage.GetCreateAccountMessage().Should().Be(Messages.Create_Account);
        }

    }
}
