using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Enumerate()
        {
            var enumerate = new List<string>(100);

            for (var i = 0; i < 100; i++)
            {
                enumerate.Add(null);
            }

            return enumerate;
        }
    }
}