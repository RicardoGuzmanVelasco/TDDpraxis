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

            result.Should().BeEquivalentTo("I", "I", "I");
        }

        [Test]
        public void Clustering_JustSubstractiveRomanNumber_ReturnsTheSameAsCluster()
        {
            var sut = new RomanNumeral("IV");

            var result = sut.ClusterSymbols();

            result.Should().BeEquivalentTo("IV");
        }

        [Test]
        public void Clustering_SubstractiveComplexRomanNumber_SplitSubstractiveAndNonSubstractiveClusters()
        {
            var sut = new RomanNumeral("DCCLXXXIX");

            var result = sut.ClusterSymbols();

            result.Should().BeEquivalentTo("D", "C", "C", "L", "X", "X", "X", "IX");
        }
        
        [Test]
        public void Clustering_SomeSubstractiveRomanNumber_SplitAllSubstractiveClusters()
        {
            var sut = new RomanNumeral("XCIX");

            var result = sut.ClusterSymbols();

            result.Should().BeEquivalentTo("XC", "IX");
        }
    }
}