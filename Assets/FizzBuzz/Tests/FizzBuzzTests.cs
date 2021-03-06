using System;
using System.Diagnostics.CodeAnalysis;
using FizzBuzz.Runtime;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
    public class FizzBuzzTests
    {
        #region Fixture
        const string Fizz = "Fizz";
        const string Buzz = "Buzz";
        const string FizzBuzz = "Fizz Buzz";
        
        const int MaxValueDivisibleBy3 = 3 * ((int.MaxValue - 1) / 3);
        const int MaxValueDivisibleBy5 = 5 * ((int.MaxValue - 1) / 5);
        const int MaxValueDivisibleBy15 = 3*5 * ((int.MaxValue - 1) / (3*5));
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
        public void FizzBuzzOf_3Multiple_Non5Multiple_IsFizz(int divisibleBy3)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(divisibleBy3);

            result.Should().Be(Fizz);
        }
        
        [TestCase(5), TestCase(10), TestCase(MaxValueDivisibleBy5)]
        public void FizzBuzzOf_5Multiple_Non3Multiple_IsBuzz(int divisibleBy5)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(divisibleBy5);

            result.Should().Be(Buzz);
        }

        [TestCase(15), TestCase(30), TestCase(MaxValueDivisibleBy15)]
        public void FizzBuzzOf_3Multiple_And5Multiple_IsFizzBuzz(int divisibleBy15)
        {
            var sut = new FizzBuzzNumber();

            var result = sut.Of(divisibleBy15);

            result.Should().Be(FizzBuzz);
        }
    }
}