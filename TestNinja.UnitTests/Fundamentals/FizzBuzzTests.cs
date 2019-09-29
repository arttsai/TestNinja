using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(2, "2")]
        public void FizzBuzz_Numbers_ReturnsCorrectAnswer(int a, string b)
        {
            var fizzBuzz = new FizzBuzz();
            var result = FizzBuzz.GetOutput(a);
            Assert.That(result, Is.EqualTo(b)); 
        }
    }
}
