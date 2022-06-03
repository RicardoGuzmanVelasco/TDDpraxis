using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class ForwardTests
    {
        [Test]
        public void EmptyGameOfLife_SameThanItsFoward()
        {
            GameOfLife.Empty
                .Forward()
                .Should().Be(GameOfLife.Empty);
        }

        [Test]
        public void DiesBy_Underpopulation_WithoutNeighbours()
        {
            GameOfLife.StartWith((15, -71))
                .Forward()
                .Should().Be(GameOfLife.Empty);
        }
        
        [Test]
        public void DiesBy_Underpopulation_With1Neighbour()
        {
            GameOfLife.StartWith((0, 89), (1, 89))
                .Forward()
                .Should().Be(GameOfLife.Empty);
        }

        [Test]
        public void Survives_With2Neighbours()
        {
            GameOfLife.StartWith((0, 0), (0, -1), (0, 1))
                .Forward()
                .IsAlive((0, 0)).Should().BeTrue();
        }
        
        [Test]
        public void Survives_With3Neighbours()
        {
            GameOfLife.StartWith((0, 0), (0, -1), (0, 1), (1, 0))
                .Forward()
                .IsAlive((0, 0)).Should().BeTrue();
        }

        [Test]
        public void DiesBy_Overpopulation_Over3Neighbours()
        {
            GameOfLife.StartWith((0, 0), (0, -1), (0, 1), (1, 0), (1, -1))
                .Forward()
                .IsAlive((0, 0)).Should().BeFalse();
        }

        [Test]
        public void Revives_ByReproduction_With3Neighbours()
        {
            GameOfLife.StartWith((0, -1), (0, 1), (1, 0))
                .Forward()
                .IsAlive((0, 0)).Should().BeTrue();
        }
    }
}