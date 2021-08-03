using System;
using FluentAssertions;
using Madison.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//[assembly: Parallelize(Workers =4,Scope =ExecutionScope.MethodLevel)]

namespace Madison.Tests
{

    [TestClass]
    public class TestLogIn : BaseTest
    {
        public static IEnumerable<object[]> GetCredentials()
        {
            yield return new object[] { User.Usernames[0], User.Passwords[0],"WELCOME, ANA ANA!" };
            yield return new object[] { User.Usernames[1], User.Passwords[1],"WELCOME, CLAU DIA!" };
            //yield return new object[] { ResourceFileHelper.Usernames[2], ResourceFileHelper.Passwords[2], ""};

        }

        [DataTestMethod]
        [DynamicData(nameof(GetCredentials), DynamicDataSourceType.Method)]
        [TestCategory ("Login")]
        public void TryToLogin(string username, string password, string expectedWelcomeMessage)
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.Login(username, password);
            Pages.LoginPage.GetWelcomeMessage().Should().Be(expectedWelcomeMessage);
        }




        [TestMethod]
        public void AlreadyRegisteredTxtDisplayed()
        {
           
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            //Pages.LoginPage.CheckLogInPageDispayed().Should().Be("Customer Login");
            Pages.LoginPage.AlreadyRegisteredTextDisplayed().Should().Be("ALREADY REGISTERED?"); 
        }

        [DoNotParallelize]
        [TestMethod]
        public void ExistingAccount()
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[5]);
            Pages.LoginPage.CheckExistingAccountMessage().Should().Be(User.AlreadyExistingAccountMessage);
        }

    }
}
