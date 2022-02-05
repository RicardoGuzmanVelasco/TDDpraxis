using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumerals.Runtime;

namespace RomanNumerals.Tests
{
    public class RomanNumeralTests
    {
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
        public void Constructor_EffectivelyTakes_RomanNumeral()
        {
            var sut = new RomanNumeral("V");

            sut.Should().NotBe(new RomanNumeral());
        }

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

        [Test]
        public void METHOD()
        {
            
        }
    }
}