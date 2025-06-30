using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator _calculator; 

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator.AllClear(); 
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(-2, -3, -5)] 
        public void Add_TwoNumbers_ReturnsCorrectSum(double a, double b, double expectedResult)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(5, 3, 2)]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference(double a, double b, double expectedResult)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(2, 3, 6)] 
        public void Multiply_TwoNumbers_ReturnsCorrectProduct(double a, double b, double expectedResult)
        {
            var result = _calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(6, 3, 2)]
        public void Divide_TwoNumbers_ReturnsCorrectQuotient(double a, double b, double expectedResult)
        {
            var result = _calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Division(5, 0));  
        }
    }
}
