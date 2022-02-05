using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumerals.Runtime;

namespace RomanNumerals.Tests
{
    public class RomanNumeralTests
    {
        [Test, Ignore("Refactoring before")]
        public void METHOD()
        {
            var sut = new RomanNumeral("II");

            int result = sut;
            
            result.Should().Be(2);
        }
        
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        public void RomanSymbols_RespectivelyEquivalent_ToNumbers(string symbols, int number)
        {
            var sut = new RomanNumeral(symbols);

            int result = sut;

            result.Should().Be(number);
        }

        #region Creation
        [Test]
        public void RomanNumeral_IsI_ByDefault()
        {
            var sut = new RomanNumeral();

            sut.Should().Be(new RomanNumeral("I"));
        }

        [Test]
        public void Constructor_Fails_IfNotJustRomanSymbols()
        {
            Action act = () => new RomanNumeral("ILj");

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Constructor_EffectivelyTakes_RomanSymbols()
        {
            var sut = new RomanNumeral("V");

            sut.Should().NotBe(new RomanNumeral());
        }
        #endregion

        #region Formatting
        [Test]
        public void RomanNumeral_ToString_ByRomanSymbols()
        {
            var sut = new RomanNumeral("XLVIII");

            sut.ToString().Should().Be("XLVIII");
        }

        [Test]
        public void RomanNumeral_Implicit_FromString()
        {
            RomanNumeral sut = "CMII";

            sut.Should().Be(new RomanNumeral("CMII"));
        }
        #endregion
    }
}