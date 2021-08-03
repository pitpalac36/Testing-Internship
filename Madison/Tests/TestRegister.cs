using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Tests
{
    [TestClass]
    class TestRegister:BaseTest 
    {
        
        [DataTestMethod]
        [DynamicData(nameof(GetAccount), DynamicDataSourceType.Method)]
        public void Registration(Account account)
        {
            Pages.HomePage.SelectMyAccountMenu(User.AccountMenu[4]);
            Pages.RegisterPage.RegisterButtonClick();

            account.Should().Be();


        }
    


        public static IEnumerable<object> GetAccount()
        {
            var password = Faker.Internet.DomainName();
            yield return new Account { LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = Faker.Name.Middle(),
                EmailAddress = Faker.Internet.Email(),
                Password = password,
                ConfirmPassword = password
        };
            yield return new Account
            {
                LastName = "",
                FirstName = Faker.Name.First(),
                MiddleName = Faker.Name.Middle(),
                EmailAddress = Faker.Internet.Email(),
                Password = password,
                ConfirmPassword = password
            };
            yield return new Account
            {
                LastName = "",
                FirstName = "",
                MiddleName = "",
                EmailAddress = "",
                Password = "",
                ConfirmPassword = ""
            };
            yield return new Account
            {
                LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = "",
                EmailAddress = "",
                Password = "",
                ConfirmPassword = ""
            };
            yield return new Account
            {
                LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = "",
                EmailAddress = Faker.Internet.Email(),
                Password = "123456",
                ConfirmPassword = ""
            };
        }

    }
}
