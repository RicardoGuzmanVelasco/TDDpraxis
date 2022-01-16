using System;
using FluentAssertions;
using NUnit.Framework;
using Ranges.Runtime;

namespace Ranges.Tests
{
    public class RangesTests
    {
        [Test]
        public void Range_IsCreated_ThroughFactoryMethod()
        {
            var sut = Range.Between(0, 2);

            sut.Should().Be(new Range(0, 2));
        }

        [Test]
        public void Range_Between_LowerAndUpperBounds()
        {
            var sut = Range.Between(1, 3);

            sut.Min.Should().Be(1);
            sut.Max.Should().Be(3);
        }

        [TestCase(2, 7, 5)]
        [TestCase(0, 0, 0)]
        public void Range_Distance_ModuleBetweenBounds(int min, int max, int distance)
        {
            var sut = Range.Between(min, max);

            var result = sut.Distance;

            result.Should().Be(distance);
        }

        [Test]
        public void Range_IsEmpty_IfDistanceIsZero()
        {
            var sutEmpty = Range.Between(4, 4);
            var sutNotEmpty = Range.Between(3, 4);

            sutEmpty.IsEmpty.Should().BeTrue();
            sutNotEmpty.IsEmpty.Should().BeFalse();
        }

        [Test]
        public void ZeroRange_IsEmpty()
        {
            Range.Zero.IsEmpty.Should().BeTrue();
        }

        #region Control
        [Test]
        public void Range_WithInvertedBounds_ThrowsException()
        {
            Action act = () => Range.Between(1, -1);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
        #endregion
    }
}