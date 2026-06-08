using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Enumerate()
        {
            var enumerate = new List<string>();

            for (var i = 1; i <= 2; i++)
            {
                enumerate.Add(i.ToString());
            }

            return enumerate;
        }
    }
}