using System.Collections.Generic;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTest
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void Translate_Position(int position, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Enumerate();

            Assert.That(result[position - 1], Is.EqualTo(expected));
        }

        [Test]
        public void Three_Returns_Fizz()
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Enumerate();

            Assert.That(result[2], Is.EqualTo("Fizz"));
        }
    }
}