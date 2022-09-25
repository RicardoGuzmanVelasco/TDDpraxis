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
            var viewMock = MockBoardView();
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
            var viewMock = MockBoardView();
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

        [Test]
        public void Move_theCursor_NotifiesView()
        {
            var viewMock = MockCursorView();
            var sut = new CursorMovement
            (
                new Cursor(columns: 10, beginIn: 7),
                viewMock
            );

            sut.Left();
            sut.Right();

            AsyncAssert(() => viewMock.MoveTo(6));
            AsyncAssert(() => viewMock.MoveTo(7));
        }

        #region TestApi
        static CursorView MockCursorView()
        {
            var result = Substitute.For<CursorView>();
            result.InvalidDirection(default).ReturnsForAnyArgs(Task.CompletedTask);
            result.MoveTo(default).ReturnsForAnyArgs(Task.CompletedTask);
            return result;
        }
        static BoardView MockBoardView()
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