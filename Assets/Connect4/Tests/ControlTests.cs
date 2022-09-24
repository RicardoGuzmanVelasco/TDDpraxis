using Connect4.Runtime.Application;
using Connect4.Runtime.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Connect4.Tests
{
    public class ControlTests
    {
        [Test]
        public void Dropping_aToken_NotifiesView()
        {
            var viewMock = Substitute.For<BoardView>();
            var sut = new TokenDrop(new Board(2, 5), viewMock);
            
            sut.InColumn(3);
            
            viewMock.Received().AddTokenIn(3);
        }
    }
}