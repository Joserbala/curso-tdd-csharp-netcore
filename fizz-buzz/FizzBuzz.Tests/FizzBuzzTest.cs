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

        [TestCase(3)]
        [TestCase(6)]
        public void Multiples_Of_3_Are_Fizz(int position)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Enumerate();

            Assert.That(result[position - 1], Is.EqualTo("Fizz"));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void Multiples_Of_5_Are_Buzz(int position)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Enumerate();

            Assert.That(result[position - 1], Is.EqualTo("Buzz"));
        }
    }
}