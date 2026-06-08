using System.Collections.Generic;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTest
    {
        [Test]
        public void List_Has_100_Elements()
        {
            var fizzBuzz = new FizzBuzz();

            List<string> result = fizzBuzz.Enumerate();
            
            Assert.That(result, Has.Count.EqualTo(100));
        }
    }
}