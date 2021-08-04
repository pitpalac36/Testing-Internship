using System.Collections.Generic;

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
