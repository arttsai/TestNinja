using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.MyTests.Fundamentals
{
    [TestFixture]
    public class LeapYearTests
    {
        private LeapYearCalculator _leaper;

        [SetUp]
        public void Setup()
        {
            _leaper = new TestNinja.Fundamentals.LeapYearCalculator();
        }

        [TestCase(1900, false)]
        [TestCase(2000, true)]
        [TestCase(1990, false)]
        public void IsLeapYear_InputYear_ReturnResult(int year, bool expectResult)
        {
            var result = _leaper.IsLeapYear(year);
            Assert.That(expectResult == result);
        }
        
        
        [Test]
        [Ignore("skip and will be back when bugs are fixed")]
        public void IsLeapYear_When1990_ReturnFalse()
        {
            var result = _leaper.IsLeapYear(1990);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsLeapYear_When2000_ReturnTrue()
        {
            var result = _leaper.IsLeapYear(2000);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsLeapYear_When1900_ReturnTrue()
        {
            var result = _leaper.IsLeapYear(1900);
            Assert.IsFalse(result);
        }
    }
}