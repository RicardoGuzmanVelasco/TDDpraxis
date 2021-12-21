using System;
using FizzBuzz.Runtime;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [TestCase(int.MinValue)]
        [TestCase(0)]
        public void FizzBuzzOf_NonPositiveNumber_ThrowsException(int nonPositiveNumber)
        {
            Action actNonPositive = () => FizzBuzzNumber.Of(nonPositiveNumber);

            actNonPositive.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void FizzBuzzOf_PositiveNumber_DoesNotThrowException(int positiveNumber)
        {
            Action actPositive = () => FizzBuzzNumber.Of(positiveNumber);
            
            actPositive.Should().NotThrow();
        }
    }
}