using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    public class BillingInformation : UserDetails
    {
        public static string Address { get; set; } = Faker.Address.StreetAddress();
        public static string City { get; set; } = Faker.Address.City();
        public static string ZIP { get; set; } = Faker.Address.ZipCode();
        public static string Telephone { get; set; } = Faker.Phone.Number();

        public override int GetNumberOfEmptyMandatoryFields()
        {
            int count = base.GetNumberOfEmptyMandatoryFields();
            if (Address == "")
                count++;
            if (City == "")
                count++;
            if (ZIP == "")
                count++;
            if (Telephone == "")
                count++;
            return count;
        }
    }
}
