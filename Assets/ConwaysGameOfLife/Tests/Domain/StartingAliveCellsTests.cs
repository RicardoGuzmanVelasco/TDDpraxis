using FluentAssertions;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests.Domain
{
    public class StartingAliveCellsTests
    {
        [Test]
        public void EmptyGameOfLife_HasNotAliveCells()
        {
            Runtime.Domain.GameOfLife
                .Empty
                .AliveCells.Should().BeEmpty();
        }

        [Test]
        public void GameOfLife_StartsAsEmpty()
        {
            Runtime.Domain.GameOfLife
                .StartWith()
                .Should().Be(Runtime.Domain.GameOfLife.Empty);
        }

        [Test]
        public void GameOfLife_RightAfterStarts_HasStartingAliveCells()
        {
            Runtime.Domain.GameOfLife
                .StartWith((0, 0), (1, 1))
                .AliveCells.Should().BeEquivalentTo((0, 0), (1, 1));
        }
    }
}