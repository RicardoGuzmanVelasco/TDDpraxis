using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class EqualityTests
    {
        [Test]
        public void ByAliveCells()
        {
            var doc = new (int x, int y)[] { (0, 0), (0, 1), (-2, 40), (34, 19330), (1, 1) };
            
            GameOfLife.StartWith(doc).Should().Be(GameOfLife.StartWith(doc));
            GameOfLife.StartWith(doc).Forward().Should().Be(GameOfLife.StartWith(doc).Forward());
        }
    }
}