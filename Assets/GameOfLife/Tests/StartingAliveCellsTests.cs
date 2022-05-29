using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class StartingAliveCellsTests
    {
        [Test]
        public void EmptyGameOfLife_HasNotAliveCells()
        {
            GameOfLife
                .Empty
                .AliveCells.Should().BeEmpty();
        }

        [Test]
        public void GameOfLife_StartsAsEmpty()
        {
            GameOfLife
                .StartWith()
                .Should().Be(GameOfLife.Empty);
        }

        [Test]
        public void GameOfLife_RightAfterStarts_HasStartingAliveCells()
        {
            GameOfLife
                .StartWith((0, 0), (1, 1))
                .AliveCells.Should().BeEquivalentTo((0, 0), (1, 1));
        }
    }
}