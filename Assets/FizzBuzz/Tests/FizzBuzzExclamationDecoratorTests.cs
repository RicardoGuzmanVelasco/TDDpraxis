using FizzBuzz.Runtime;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzExclamationDecoratorTests
    {
        [TestCase(1), TestCase(2), TestCase(4), TestCase(7)]
        public void FizzBuzzOf_CommonNumber_DoesNotEndWithExclamationMark(int commonNumber)
        {
            var sut = new FizzBuzzExclamationDecorator(new FizzBuzzNumber());

            var result = sut.Of(commonNumber);

            result.Should().NotEndWith("!");
        }
        
        [TestCase(3), TestCase(5), TestCase(6), TestCase(10), TestCase(15), TestCase(30)]
        public void FizzBuzzOf_SpecialNumber_EndsWithExclamationMark(int specialNumber)
        {
            var sut = new FizzBuzzExclamationDecorator(new FizzBuzzNumber());

            var result = sut.Of(specialNumber);

            result.Should().EndWith("!");
        }
    }
}