using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

//[assembly: Parallelize(Workers =4,Scope =ExecutionScope.MethodLevel)]
namespace Madison.Tests
{

    [TestClass]
    public class LoginTest : MadisonTest
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
        public void LoginActionTest (string username, string password, string expectedWelcomeMessage )
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username, password );
            Pages.MyAccountPage.GetWelcomeMessage().Should().Be(expectedWelcomeMessage);
        }

        [Ignore]
        [TestMethod]
        public void AlreadyRegisteredMessageTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.GetAlreadyRegisteredMessage().Should().Be(Messages.Registered); 
        }

        [Ignore]
        [TestMethod]
        public void ExistingAccountMessageTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.GetExistingAccountMessage().Should().Be(Messages.Existing_Account);
        }
      
        [TestMethod]
        [TestCategory("Login")]
        public void CreateAnAccountTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.ClickCreateAccount();

            Pages.LoginPage.GetCreateAccountMessage().Should().Be(Messages.Create_Account);
        }
        
        [TestMethod]
        [TestCategory("Login")]
        public void TryToLoginTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.ClickLogInBtn();

            Pages.LoginPage.IsRequiredMessageDisplayed().Should().BeTrue();
            Pages.RegisterPage.GetErrorMessagesFromForm().Should().OnlyContain(x => x.Equals(Messages.Mandatory_Error));
        }
        
        [TestMethod]
        [TestCategory("Login")]
        public void TestSearchFromLoginPageTest()
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Search();

            Pages.LoginPage.IsSearchResultsMessageDisplayed().Should().BeTrue();
        }
       
        [DataTestMethod]
        [TestCategory("Login")]
        [DynamicData(nameof(GetCredentials), DynamicDataSourceType.Method)]
        public void CheckIfIvalidMessageIsDisplayedTest (string username, string password)
        {
            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username, password );

            Pages.LoginPage.IsInvalidLoginMessageDisplayed().Should().BeTrue();
        }
        
        [DataTestMethod]
        [TestCategory("Login")]
        [DynamicData(nameof(GetPassword), DynamicDataSourceType.Method)]
        public void LoginWithEmptyEmailTest (string username, string password )
        {

            Pages.HomePage.SelectMyAccountMenu(Menu.Login.GetDescription());
            Pages.LoginPage.Login (username,password );

            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
        }
    }
}
