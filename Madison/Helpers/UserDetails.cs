
namespace Madison.Helpers
{
    public class UserDetails
    {
        private static readonly string _password = Faker.Internet.DomainName();
        public static string FirstName { get; set; } = Faker.Name.First();
        public static string MiddleName { get; set; } = Faker.Name.Middle();
        public static string LastName { get; set; } = Faker.Name.Last();
        public static string EmailAddress { get; set; } = Faker.Internet.Email();
        public static string Password { get; set; } = _password;
        public static string ConfirmPassword { get; set; } = _password;
        public  int GetNumberOfEmptyMandatoryFields()
        {
            int count = 0;
            if (FirstName == "")
                count += 1;
            if (LastName == "")
                count += 1;
            if (EmailAddress == "")
                count += 1;
            if (Password == "")
                count += 1;
            if (ConfirmPassword == "")
                count += 1;
            return count;
        }
    }
}
