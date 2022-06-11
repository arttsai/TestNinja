using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }
        
        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(2, 2, 4)]
        public void Add_WhenInput_ExpectCorrect(int a, int b, int result)
        {
            Assert.That(_math.Add(a, b) == result);
        }

        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        public void Max_WhenInput_ExpectCorrectResult(int a, int b, int result)
        {
            Assert.That(_math.Max(a, b) == result);
        }

        [TestCase(1, new int[]{1})]
        [TestCase(2, new int[] {1})]
        [TestCase(3, new int[]{1,3})]
        [TestCase(9, new int[]{1,3,5,7,9})]
        [TestCase(10, new int[]{1,3,5,7,9})]
        public void GetOddNumbers_WhenInput_ExpectCorrectResult(int a, int[] oddNumberArray)
        {
            var result = new List<int>();
            foreach (var i in _math.GetOddNumbers(a))
            {
                result.Add(i);
            }

            var isEqual = result.SequenceEqual(oddNumberArray);
            Assert.AreEqual(isEqual, true);
        }
        
    }
}