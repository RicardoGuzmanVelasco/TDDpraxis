using FizzBuzz.Runtime;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzMultipleTransmutatorTests
    {
        [TestCase(3, "Fizz"), TestCase(5, "Buzz"), TestCase(3*5, "Fizz Buzz")]
        public void WhenNumberIsMultiple_ReturnsWord(int number, string word)
        {
            var sut = new FizzBuzzWordTransmutator(number, word);

            var result = sut.Of(number);

            result.Should().Be(word);
        }
        
        [Test]
        public void WhenNumberIsNotMultiple_ReturnsEmpty()
        {
            var sut = new FizzBuzzWordTransmutator(2, "Something");

            var result = sut.Of(3);

            result.Should().BeEmpty();
        }
    }
}