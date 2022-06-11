using Castle.Core.Internal;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_ErrorIsEmpty_ThrowException()
        {
            var logger = new ErrorLogger();
            Assert.Catch(() => { logger.Log(null); });
        }

        [Test]
        public void Log_Add2Logs_LastErrorIsCorrect()
        {
            var logger = new ErrorLogger();
            logger.Log("1");
            logger.Log("2");
            Assert.AreEqual(logger.LastError, "2");
        }

        [Test]
        public void Log_SubscribeEvent_GetInvoked()
        {
            var logger = new ErrorLogger();
            var msg = "";
            logger.ErrorLogged += (o, guid) => { msg = guid.ToString(); };

            logger.Log("1");
            
            Assert.That(!msg.IsNullOrEmpty());
        }
        
    }
}