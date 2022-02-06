using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RomanNumerals.Runtime;

namespace RomanNumerals.Tests
{
    public class RomanNumeralInternalTests
    {
        [Test]
        public void Clustering_SameSymbolRomanNumber_SplitsAllChars()
        {
            var sut = new RomanNumeral("III");

            var result = sut.ClusterSymbols();

            result.Should().HaveCount(3);
            result.Should().OnlyContain(s => s == "I");
        }

        [Test]
        public void Clustering_JustSubstractiveRomanNumber_ReturnsTheSameAsCluster()
        {
            var sut = new RomanNumeral("IV");

            var result = sut.ClusterSymbols();

            result.Should().HaveCount(1);
            result.Should().OnlyContain(s => s == "IV");
        }

        [Test]
        public void Clustering_SubstractiveComplexRomanNumber_SplitSubstractiveAndNonSubstractiveClusters()
        {
            var sut = new RomanNumeral("DCCLXXXIX");

            var result = sut.ClusterSymbols();

            result.Where(s => s == "D").Should().HaveCount(1);
            result.Where(s => s == "C").Should().HaveCount(2);
            result.Where(s => s == "L").Should().HaveCount(1);
            result.Where(s => s == "X").Should().HaveCount(3);
            result.Should().Contain("IX");
        }
    }
}