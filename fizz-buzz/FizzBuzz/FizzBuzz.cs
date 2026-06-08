using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Enumerate()
        {
            var enumerate = new List<string>();

            for (var i = 1; i <= 3; i++)
            {
                if (i == 3)
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
    }
}