using FluentAssertions;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests.Domain
{
    public class StillLifesTest
    {
        [Test]
        public void GameOfLife_Block_IsStillLife()
        {
            Runtime.Domain.GameOfLife.StartWith((0, 0), (0, 1), (1, 0), (1, 1))
                .IsStill()
                .Should().BeTrue();
        }
        
        [Test]
        public void GameOfLife_Beehive_IsStillLife()
        {
            Runtime.Domain.GameOfLife.StartWith((0, 1), (1, 0), (2, 0), (1, 2), (2, 2), (3, 1))
                .IsStill()
                .Should().BeTrue();
        }
    }
}