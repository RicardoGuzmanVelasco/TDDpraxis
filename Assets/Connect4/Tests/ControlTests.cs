using System;
using System.Threading.Tasks;
using Connect4.Runtime.Application;
using Connect4.Runtime.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Connect4.Tests
{
    public class ControlTests
    {
        [Test]
        public async Task Dropping_aToken_NotifiesView()
        {
            var viewMock = MockView();
            var sut = new TokenDrop(new Board(2, 5), viewMock);
            
            await sut.InColumn(3);

            AsyncAssert(() => viewMock.AddTokenIn(3));
        }

        [Test]
        public async Task TryingDrop_inFullColumn_NotifiesErrorToView()
        {
            var viewMock = MockView();
            var model = new Board(1, 5);
            var sut = new TokenDrop(model, viewMock);

            model.DropInColumn(4);
            await sut.InColumn(4);

            AsyncAssert(() => viewMock.ShowColumnAsFull(4));
        }

        static BoardView MockView()
        {
            var result = Substitute.For<BoardView>();
            result.ShowColumnAsFull(default).ReturnsForAnyArgs(Task.CompletedTask);
            result.AddTokenIn(default).ReturnsForAnyArgs(Task.CompletedTask);
            return result;
        }

        static void AsyncAssert(Func<Task> func)
        {
            Received.InOrder(async () => await func());
        }
    }
}