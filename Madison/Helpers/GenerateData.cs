using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Helpers
{
    class GenerateData
    {
        public static List<int>   GenerateNumbersListBasedOnCount(int count)
        {
            List<int> numbers = new ();
            for(int i=0;i<count;i++)
            {
                var number = Faker.RandomNumber.Next(2,25);
                numbers.Add(number);
            }
            return numbers;
        }
     }
}
