using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    public class Account
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int GetNumberOfEmptyMandatoryFields()
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
