using System;
using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

[assembly: Parallelize(Workers =4,Scope =ExecutionScope.MethodLevel)]

namespace Madison.Tests
{

    [TestClass]
    public class TestLogIn : BaseTest
    {

        [TestMethod]
        [TestCategory ("Login")]
        public void TryLogin()
        {
            Pages.HomePage.SelectMyAccountMenu("Log In");
            Pages.LoginPage.Login();
        }

        [TestMethod]
        public void AlreadyRegisteredTxtDisplayed()
        {
           
            Pages.HomePage.SelectMyAccountMenu("Log In");
            //Pages.LoginPage.CheckLogInPageDispayed().Should().Be("Customer Login");
            Pages.LoginPage.AlreadyRegisteredTextDisplayed().Should().Be("ALREADY REGISTERED?"); 
        }
        [DoNotParallelize]
        [TestMethod]
        public void ExistingAccount()
        {
            Pages.HomePage.SelectMyAccountMenu("Log In");
            Pages.LoginPage.CheckExistingAccountMessage().Should().Be("If you have an account with us, please log in.");
        }

    }
}
