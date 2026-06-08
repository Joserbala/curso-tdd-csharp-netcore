using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Enumerate()
        {
            var enumerate = Enumerable.Repeat("", 100);
            return enumerate.Select((_, i) => Translate(i + 1)).ToList();
        }

        private static string Translate(int number)
        {
            if (IsFizz(number) && IsBuzz(number))
            {
                return "FizzBuzz";
            }

            if (IsBuzz(number))
            {
                return "Buzz";
            }

            if (IsFizz(number))
            {
                return "Fizz";
            }

            return number.ToString();
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