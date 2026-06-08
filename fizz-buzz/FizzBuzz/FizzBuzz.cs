using System.Collections.Generic;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Enumerate()
        {
            var enumerate = new List<string>();

            for (var i = 1; i <= 100; i++)
            {
                if (IsFizz(i) && IsBuzz(i))
                {
                    enumerate.Add("FizzBuzz");
                }
                else if (IsBuzz(i))
                {
                    enumerate.Add("Buzz");
                }
                else if (IsFizz(i))
                {
                    enumerate.Add("Fizz");
                }
                else
                {
                    enumerate.Add(i.ToString());
                }
            }

            return enumerate;
        }

        private static bool IsFizz(int number)
        {
            return number % 3 == 0;
        }

        private static bool IsBuzz(int number)
        {
            return number % 5 == 0;
        }
    }
}