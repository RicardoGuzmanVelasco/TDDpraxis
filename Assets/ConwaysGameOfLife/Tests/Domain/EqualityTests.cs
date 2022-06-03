using FluentAssertions;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests.Domain
{
    public class EqualityTests
    {
        [Test]
        public void ByAliveCells()
        {
            var doc = new (int x, int y)[] { (0, 0), (0, 1), (-2, 40), (34, 19330), (1, 1) };
            
            Runtime.Domain.GameOfLife.StartWith(doc).Should().Be(Runtime.Domain.GameOfLife.StartWith(doc));
            Runtime.Domain.GameOfLife.StartWith(doc).Forward().Should().Be(Runtime.Domain.GameOfLife.StartWith(doc).Forward());
        }
    }
}