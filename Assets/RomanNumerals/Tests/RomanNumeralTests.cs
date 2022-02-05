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

            sut.Should().Be(RomanNumeral.I);
        }

        [Test]
        public void DefaultRomanNumeral_IsAlsoCreated_ByConstructor()
        {
            var sut = new RomanNumeral("I");

            sut.Should().Be(RomanNumeral.I);
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
    }
}