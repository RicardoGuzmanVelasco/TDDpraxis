using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class StillLifesTest
    {
        [Test]
        public void GameOfLife_Block_IsStillLife()
        {
            var sut = GameOfLife.StartWith((0, 0), (0, 1), (1, 0), (1, 1));
            sut.Forward()
                .Should().Be(sut);
        }
        
        [Test]
        public void GameOfLife_Beehive_IsStillLife()
        {
            var sut = GameOfLife.StartWith((0, 1), (1, 0), (2, 0), (1, 2), (2, 2), (3, 1));
            sut.Forward()
                .Should().Be(sut);
        }
    }
}