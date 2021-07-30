using System;
using FluentAssertions;
using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace Madison.Tests
{

    [TestClass]
    public class TestLogIn : BaseTest
    {

        [TestMethod]
        public void AccountMenuAccessLogInButton()
        {
            Pages.HomePage.ClickOnAccount();
            Pages.HomePage.ClickLogInButton();
            Pages.LoginPage.FillCredentials();
            Pages.LoginPage.LogInSubmit();
        }

    }
}
