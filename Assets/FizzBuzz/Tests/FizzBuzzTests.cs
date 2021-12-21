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
        const string Buzz = "Buzz";
        
        const int MaxValueDivisibleBy3 = 3 * ((int.MaxValue - 1) / 3);
        #endregion
        
        #region Control cases
        [TestCase(int.MinValue), TestCase(0)]
        public void FizzBuzzOf_NonPositiveNumber_ThrowsException(int nonPositive)
        {
            Action actNonPositive = () => new FizzBuzzNumber().Of(nonPositive);

            actNonPositive.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(1), TestCase(int.MaxValue)]
        public void FizzBuzzOf_PositiveNumber_DoesNotThrowException(int positive)
        {
            Action actPositive = () => new FizzBuzzNumber().Of(positive);
            
            actPositive.Should().NotThrow();
        }
        #endregion
        
        [TestCase(1), TestCase(2), TestCase(4), TestCase(7)]
        public void FizzBuzzOf_Neither3Nor5Multiple_ReturnsTheNumber(int notDisibleBy3Nor5)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(notDisibleBy3Nor5);

            result.Should().Be(notDisibleBy3Nor5.ToString());
        }

        [TestCase(3), TestCase(6), TestCase(MaxValueDivisibleBy3)]
        public void FizzBuzzOf_3Multiple_IsFizz(int divisibleBy3)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(divisibleBy3);

            result.Should().Be(Fizz);
        }
        
        [Test]
        public void FizzBuzzOf_5_IsBuzz()
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(5);

            result.Should().Be(Buzz);
        }
    }
}