using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class DateHelperTests
    {
        [TestCase("2022/10/31", "2022/11/1")]
        [TestCase("2022/12/31", "2023/1/1")]
        public void FirstOfNextMonth_WhenInput_ExpectCorrectResult(DateTime orgDt, DateTime expectDt)
        {
            Assert.AreEqual(DateHelper.FirstOfNextMonth(orgDt), expectDt);
        }
    }
}