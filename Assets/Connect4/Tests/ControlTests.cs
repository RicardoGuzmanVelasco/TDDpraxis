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
            var sut = new TokenDrop
            (
                new Board(1, columns: 5),
                new Cursor(columns: 5, beginIn: 3),
                viewMock
            );
            
            await sut.InCurrentColumn();

            AsyncAssert(() => viewMock.AddTokenIn(3));
        }

        [Test]
        public async Task TryingDrop_inFullColumn_NotifiesErrorToView()
        {
            var viewMock = MockView();
            var model = new Board(1, 5);
            var sut = new TokenDrop
            (
                model,
                new Cursor(columns: 5, beginIn: 4),
                viewMock
            );

            model.DropInColumn(4);
            await sut.InCurrentColumn();

            AsyncAssert(() => viewMock.ShowColumnAsFull(4));
        }

        #region TestApi
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
        #endregion
    }
}