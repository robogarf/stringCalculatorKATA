using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void ShouldReturn0ForEmptyString()
        {
            var result = _stringCalculator.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase("3", 3)]
        [TestCase("8", 8)]
        public void ShouldReturnSameNumberForSingleNumber(string number, int expectedResult)
        {
            var actualResult = _stringCalculator.Add(number);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("3,5", 8)]
        [TestCase("3,8", 11)]
        public void ShouldReturnSumForTwoNumbers(string numbers, int expectedResult)
        {
            var actualResult = _stringCalculator.Add(numbers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("3,5,1", 9)]
        [TestCase("3,8,4,5", 20)]
        public void ShouldReturnSumForUnknownAmountOfNumbers(string numbers, int expectedResult)
        {
            var actualResult = _stringCalculator.Add(numbers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnSumForCommaOrNewLineDelimeter()
        {
            var actualResult = _stringCalculator.Add("1\n2,2");

            Assert.That(actualResult, Is.EqualTo(5));
        }

        [Test]
        [TestCase("//;\n1;2;2", 5)]
        [TestCase("//!\n3!8!4!5", 20)]
        public void ShouldReturnSumForCustomDelimeter(string numbers, int expectedResult)
        {
            var actualResult = _stringCalculator.Add(numbers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("-1,-5,6,7", "-1, -5")]
        [TestCase("3,7,8,-2,-5", "-2, -5")]
        public void ShouldThrowExceptionWhenInputContainsNegativeNumbers(string numbers, string exceptionMessage)
        {
            TestDelegate actualResult = () => _stringCalculator.Add(numbers);

            var negativesNotAllowedException = Assert.Throws<NegativesNotAllowedException>(actualResult);
            Assert.That(negativesNotAllowedException.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
