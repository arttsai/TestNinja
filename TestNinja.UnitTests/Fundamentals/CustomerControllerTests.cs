using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIs0_ReturnNotFoundObject()
        {
            var cc = new CustomerController();
            var rlt = cc.GetCustomer(0);
            Assert.IsInstanceOf<NotFound>(rlt);
        }

        [Test]
        public void GetCustomer_IdIsNot0_ReturnOkObject()
        {
            var cc = new CustomerController();
            var rlt = cc.GetCustomer(10);
            Assert.IsInstanceOf<Ok>(rlt);
        }
    }
}