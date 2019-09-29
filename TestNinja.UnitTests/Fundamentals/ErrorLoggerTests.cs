using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void ErrorLogger_WhenCalled_GetLastError()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a")); 
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ErrorLogger_NullOrWhiteSpaceErrorString_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException); 
        }
    }
}
