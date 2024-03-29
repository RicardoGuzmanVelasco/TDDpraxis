using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumerals.Runtime;

namespace RomanNumerals.Tests
{
    public class RomanNumeralTests
    {
        #region SupportMethods
        static void FromRomanNumeralToNumber(string symbols, int number)
        {
            var sut = new RomanNumeral(symbols);

            int result = sut;

            result.Should().Be(number);
        }
        
        static void FromNumberToRomanNumeral(int number, string symbols)
        {
            var sut = new RomanNumeral(number);
            
            sut.Should().Be(new RomanNumeral(symbols));
        }
        #endregion

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

        [TestCase("IIII")]
        [TestCase("XXXX")]
        [TestCase("CCCC")]
        public void AdditiveNotation_IsNotSupported(string additiveNotation)
        {
            Action act = () => new RomanNumeral(additiveNotation);

            act.Should().ThrowExactly<NotSupportedException>();
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RomanNumeral_CreatedByNumber_MustBePositive(int nonPositive)
        {
            Action act = () => new RomanNumeral(nonPositive);
            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
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

        #region To number, Partition & EquivalenceClasses
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        public void RomanSymbols_RespectivelyEquivalent_ToNumbers(string symbols, int number)
        {
            FromRomanNumeralToNumber(symbols, number);
        }

        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("VI", 6)]
        [TestCase("CLV", 155)]
        public void NonSubstractive_IsEquivalentTo_ItsSymbolsSum(string symbols, int number)
        {
            FromRomanNumeralToNumber(symbols, number);
        }

        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        public void JustSubstractive_IsEquivalentTo_ItsReversedSymbolsSubstraction(string symbols, int number)
        {
            FromRomanNumeralToNumber(symbols, number);
        }

        [TestCase("CMIV", 904)]
        [TestCase("MDCCLXXIV", 1774)]
        [TestCase("MCMXCIX", 1999)]
        public void SomeSubstractive_IsEquivalentTo_ItsIndependentSubstractionAdded(string symbols, int number)
        {
            FromRomanNumeralToNumber(symbols, number);
        }
        #endregion
        
        
        #region From number, Partition & EquivalenceClasses
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(11, "XI")]
        [TestCase(1565, "MDLXV")]
        public void RomanNumeral_CreatedFromNumber_WithJustAdditiveSymbols(int number, string symbols)
        {
            FromNumberToRomanNumeral(number, symbols);
        }
        
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        public void RomanNumeral_CreatedFromNumber_WithJustSubstractiveSymbols(int number, string symbols)
        {
            FromNumberToRomanNumeral(number, symbols);
        }
        #endregion
    }
}