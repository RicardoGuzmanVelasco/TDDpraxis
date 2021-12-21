using System;
using FizzBuzz.Runtime;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        #region Fixture
        const string Fizz = "Fizz";
        #endregion
        
        #region Control cases
        [TestCase(int.MinValue)] [TestCase(0)]
        public void FizzBuzzOf_NonPositiveNumber_ThrowsException(int nonPositiveNumber)
        {
            Action actNonPositive = () => new FizzBuzzNumber().Of(nonPositiveNumber);

            actNonPositive.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(1)] [TestCase(int.MaxValue)]
        public void FizzBuzzOf_PositiveNumber_DoesNotThrowException(int positiveNumber)
        {
            Action actPositive = () => new FizzBuzzNumber().Of(positiveNumber);
            
            actPositive.Should().NotThrow();
        }
        #endregion
        
        [TestCase(1)] [TestCase(2)] [TestCase(4)] [TestCase(7)]
        public void FizzBuzzOf_Neither3Nor5Multiple_ReturnsTheNumber(int positiveNumber)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(positiveNumber);

            result.Should().Be(positiveNumber.ToString());
        }

        [Test]
        public void FizzBuzzOf_3_IsFizz()
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(3);

            result.Should().Be(Fizz);
        }
    }
}