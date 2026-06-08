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
                var result = Translate(i);

                enumerate.Add(result);
            }

            return enumerate;
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