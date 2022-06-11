using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        [Test]
        public void OverlappingBookingsExist_StatusIsCancelled_ReturnEmptyString()
        {
            var booking = new Booking() {Status = "Cancelled", Id = 1};
            Assert.That(BookingHelper.OverlappingBookingsExist(booking), Is.EqualTo(string.Empty));
        } 
    }
    
    // Check internet to find out how this overlapped thing is verified 
}