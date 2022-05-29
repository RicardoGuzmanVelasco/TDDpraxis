using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class ForwardTests
    {
        static readonly (int x, int y) AnyRandomCoord = (15, -71);
        
        [Test]
        public void EmptyGameOfLife_SameThanItsFoward()
        {
            GameOfLife.Empty
                .Forward()
                .Should().Be(GameOfLife.Empty);
        }

        [Test]
        public void GameOfLife_WithOneCell_Forward_ThatCellsDies()
        {
            GameOfLife.StartWith(AnyRandomCoord)
                .Forward()
                .AliveCells.Should().BeEmpty();
        }

        [Test]
        public void GameOfLife_Block_IsStillLife()
        {
            var sut = GameOfLife.StartWith((0, 0), (0, 1), (1, 0), (1, 1));
            sut.Forward().ToString().Should().Be(sut.ToString());
        }
    }
}