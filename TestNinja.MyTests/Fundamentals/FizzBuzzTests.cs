using NUnit.Framework;

namespace TestNinja.MyTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void FizzBuzz_Input_ReturnResult(int number, string expectedResult)
        {
            var result = TestNinja.Fundamentals.FizzBuzz.GetOutput(number);
            Assert.That(result == expectedResult);
        }
    }
}