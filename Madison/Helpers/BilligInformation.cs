using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    public class BillingInformation : UserDetails
    {
        public string Address { get; set; } = Faker.Address.StreetAddress();
        public string City { get; set; } = Faker.Address.City();
        public string ZIP { get; set; } = Faker.Address.ZipCode();
        public string Telephone { get; set; } = Faker.Phone.Number();

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
