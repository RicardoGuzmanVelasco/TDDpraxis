using System;
using FluentAssertions;
using NUnit.Framework;
using Ranges.Runtime;

namespace Ranges.Tests
{
    public class RangesTests
    {
        #region Creation
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
        #endregion

        #region Length
        [TestCase(2, 7, 5)]
        [TestCase(0, 0, 0)]
        public void Range_Length_ModuleBetweenBounds(int min, int max, int length)
        {
            var sut = Range.Between(min, max);

            var result = sut.Length;

            result.Should().Be(length);
        }

        [Test]
        public void Range_IsEmpty_IfLengthIsZero()
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
        #endregion
        
        #region Operations
        [Test]
        public void Range_IncludesNumber_IfWithinBounds()
        {
            Range.Between(3, 4).Includes(4).Should().BeTrue();
            Range.Between(3, 4).Includes(3).Should().BeTrue();
            Range.Between(3, 5).Includes(5).Should().BeTrue();
            
            Range.Between(3, 4).Includes(2f).Should().BeFalse();
            Range.Between(3, 4).Includes(6.0).Should().BeFalse();
        }

        [Test]
        public void Range_IncludesRange_IfBothEdgesWithinBounds()
        {
            Range.Between(70, 90).Includes(Range.Between(71, 89)).Should().BeTrue();
            Range.Between(70, 90).Includes(Range.Between(70, 71)).Should().BeTrue();
            Range.Between(70, 90).Includes(Range.Between(89, 90)).Should().BeTrue();
            
            Range.Between(70, 90).Includes(Range.Between(60, 69)).Should().BeFalse();
            Range.Between(70, 90).Includes(Range.Between(91, 99)).Should().BeFalse();
            Range.Between(70, 90).Includes(Range.Between(60, 71)).Should().BeFalse();
            Range.Between(70, 90).Includes(Range.Between(89, 91)).Should().BeFalse();
            Range.Between(70, 90).Includes(Range.Between(69, 99)).Should().BeFalse();
        }

        [Test]
        public void Range_IncludesItself()
        {
            Range.Between(1, 3)
                 .Includes(Range.Between(1, 3))
                 .Should().BeTrue();
        }
        #endregion

        #region Operators
        [Test]
        public void RangesEquality_IsTrue_IfSameBounds()
        {
            (Range.Between(8, 9) == new Range(8, 9)).Should().BeTrue();
            Range.Between(8, 9).Equals(new Range(8, 9)).Should().BeTrue();
            Range.Between(8, 9).GetHashCode().Should().Be(new Range(8, 9).GetHashCode());

            (Range.Between(4, 7) == new Range(1, 2)).Should().BeFalse();
            Range.Between(4, 7).Equals(new Range(1, 2)).Should().BeFalse();
            Range.Between(4, 7).GetHashCode().Should().NotBe(new Range(1, 2).GetHashCode());
        }
        
        [Test]
        public void RangesInequality_IsTrue_IfNotSameBounds()
        {
            (Range.Between(2, 3) != new Range(8, 9)).Should().BeTrue();
            (Range.Between(5, 8) != new Range(5, 8)).Should().BeFalse();
        }
        
        [Test]
        public void Range_IsLesserThanOther_IfMaxIsLesserOrSameThanOtherMin()
        {
            (Range.Between(1, 2) < Range.Between(2, 3)).Should().BeTrue();
            (Range.Between(1, 5) < Range.Between(6, 7)).Should().BeTrue();
            
            (Range.Between(1, 3) < Range.Between(1, 2)).Should().BeFalse();
            (Range.Between(5, 5) < Range.Between(4, 5)).Should().BeFalse();
        }
        
        [Test]
        public void Range_IsGreaterThanOther_IfMinIsGreaterOrSameThanOtherMax()
        {
            (Range.Between(47, 88) > Range.Between(20, 47)).Should().BeTrue();
            (Range.Between(17, 18) > Range.Between(11, 16)).Should().BeTrue();
            
            (Range.Between(91, 92) > Range.Between(41, 92)).Should().BeFalse();
            (Range.Between(74, 75) > Range.Between(79, 87)).Should().BeFalse();
        }
        #endregion

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