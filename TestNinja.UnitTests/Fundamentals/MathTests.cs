using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private TestNinja.Fundamentals.Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new TestNinja.Fundamentals.Math();
        }


        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3)); 
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnsRightAnswer(int a, int b, int c)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [Test]
        public void GetOddNumbers_WhenCalled_Returns()
        {
            IEnumerable<int> result = _math.GetOddNumbers(5);
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5 }));
        }
    }
}
