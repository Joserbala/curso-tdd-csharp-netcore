using System;
using NUnit.Framework;

namespace PureGreeter.Tests
{
    [TestFixture]
    public class PureGreeterTest
    {
        private PureGreeter _pureGreeter;

        [SetUp]
        public void Init()
        {
            _pureGreeter = new PureGreeter();
        }
        
        [Test]
        public void Greet_during_the_morning()
        {
            var greeting = _pureGreeter.Greet(8, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenos días Pepe!"));
        }

        [Test]
        public void Greet_during_the_afternoon()
        {
            var greeting = _pureGreeter.Greet(15, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenas tardes Pepe!"));
        }

        [Test]
        public void Greet_during_the_night()
        {
            var greeting = _pureGreeter.Greet(22, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenas noches Pepe!"));
        }

        [Test]
        public void Greeting_hours_should_be_between_0_and_23()
        {
            Assert.Throws<ArgumentException>(() => _pureGreeter.Greet(40, "Pepe"));
        }
    }
}