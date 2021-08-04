using Madison.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Madison.Tests
{
    [TestClass]
    public class RegisterTest:BaseTest 
    {
        
        [TestMethod]
        //[DynamicData(nameof(GetAccount), DynamicDataSourceType.Method)]
        public void Registration()
        {
            UserDetails userDetails = new ();
            Pages.HomePage.SelectMyAccountMenu(Constants.AccountMenu[4]);
            Pages.RegisterPage.ClickRegisterButton();

            Pages.RegisterPage.GetErrorMessagesFromForm().Should().OnlyContain(x => x.Equals(Messages.Mandatory_Error));

            Pages.RegisterPage.FillRegistrationForm();
            Pages.RegisterPage.SubscribeToNewsletter();
            Pages.RegisterPage.ClickRegisterButton();

            Pages.RegisterPage.GetErrorMessagesFromForm().Should().HaveCount(userDetails.GetNumberOfEmptyMandatoryFields());
            Pages.RegisterPage.GetSuccessMessage().Should().Be(Messages.Success_Login);
            Pages.RegisterPage.MergeUserNameWithWelcome().Should().Be(Pages.MyAccountPage.GetWelcomeMessage());
        }
   

        /*public static IEnumerable<object[]> GetAccount()
        {
            var password = Faker.Internet.DomainName();
            yield return new object[] { new UserDetails {LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = Faker.Name.Middle(),
                EmailAddress = Faker.Internet.Email(),
                Password = password,
                ConfirmPassword = password
            } };
            yield return new object[]
            {
                new UserDetails{
                LastName = "",
                FirstName = Faker.Name.First(),
                MiddleName = Faker.Name.Middle(),
                EmailAddress = Faker.Internet.Email(),
                Password = password,
                ConfirmPassword = password
                } };
            yield return new object[]
            {new UserDetails{
                LastName = "",
                FirstName = "",
                MiddleName = "",
                EmailAddress = "",
                Password = "",
                ConfirmPassword = ""
            } };
            yield return new object[]
            { new UserDetails{
                LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = "",
                EmailAddress = "",
                Password = "",
                ConfirmPassword = ""
            } };
            yield return new object[]
            { new UserDetails{
                LastName = Faker.Name.Last(),
                FirstName = Faker.Name.First(),
                MiddleName = "",
                EmailAddress = Faker.Internet.Email(),
                Password = "123456",
                ConfirmPassword = ""
            } };
        }*/

    }
}
