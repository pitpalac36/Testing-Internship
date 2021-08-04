using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

//[assembly: Parallelize(Workers =4,Scope =ExecutionScope.MethodLevel)]
namespace Madison.Tests
{

    [TestClass]
    public class LoginTest : BaseTest
    {
        public static IEnumerable<object[]> GetCredentialsAndWelcomeMessage()
        {
            yield return new object[] { Constants.Usernames[0], Constants.Passwords[0],"WELCOME, ANA ANA!" };
            yield return new object[] { Constants.Usernames[1], Constants.Passwords[1],"WELCOME, CLAU DIA!" };
        }
        public static IEnumerable<object[]> GetCredentials()
        {
            yield return new object[] { Constants.Usernames[0], Faker.Internet.DomainName()};
            yield return new object[] { Constants.Usernames[1], Faker.Internet.DomainName() };
        }

        public static IEnumerable<object[]> GetPassword()
        {
            yield return new object[] {"", Faker.Internet.DomainName() };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCredentialsAndWelcomeMessage), DynamicDataSourceType.Method)]
        [TestCategory ("Login")]
        public void LoginAction (string username, string password, string expectedWelcomeMessage )
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username, password );
            Pages.MyAccountPage.GetWelcomeMessage().Should().Be(expectedWelcomeMessage);
        }

        [Ignore]
        [TestMethod]
        public void AlreadyRegisteredMessage()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.GetAlreadyRegisteredMessage().Should().Be(Messages.Registered); 
        }

        [Ignore]
        [TestMethod]
        public void ExistingAccountMessage()
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

        [TestMethod]
        public void TryToLogin()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.ClickLogInBtn();

            Pages.LoginPage.IsRequiredMessageDisplayed().Should().BeTrue();
            Pages.RegisterPage.GetErrorMessagesFromForm().Should().OnlyContain(x => x.Equals(Messages.Mandatory_Error));
        }

        [TestMethod]
        public void TestSearchFromLoginPage()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.CheckSearch();

            Pages.LoginPage.IsSearchResultsMessageDisplayed().Should().BeTrue();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCredentials), DynamicDataSourceType.Method)]
        public void ForgetPassword (string username, string password)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username, password );

            Pages.LoginPage.IsInvalidLoginMessageDisplayed().Should().BeTrue();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetPassword), DynamicDataSourceType.Method)]
        public void NoEmailEntered (string username, string password )
        {

            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username,password );

            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
        }

    }
}
