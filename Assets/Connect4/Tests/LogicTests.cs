using Connect4.Runtime.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Connect4.Tests
{
    public class LogicTests
    {
        [Test]
        public void Drop_aToken_inBoard()
        {
            var sut = new Board(rows: 6, columns: 7);
            var spy = sut.Monitor();

            sut.DropInColumn(4);

            spy.Should()
                .Raise(nameof(Board.TokenDroppedInColumn))
                .WithArgs<int>(r => r == 4);
        }

        [Test]
        public void CannotDrop_aToken_inFullColumn()
        {
            var sut = new Board(rows: 1, columns: 2);
            sut.DropInColumn(1);
            var spy = sut.Monitor();
            
            sut.DropInColumn(1);

            spy.Should().NotRaise(nameof(Board.TokenDroppedInColumn));
        }

        [Test]
        public void Drop_4Times_inSameColumn_IsNotWinStill()
        {
            var sut = new Board(rows: 4, columns: 1);
            sut.DropInColumn(1);
            sut.DropInColumn(1);
            sut.DropInColumn(1);

            sut.WinsIfDropsIn(1)
                .Should().BeFalse();
        }

        [Test]
        public void toFill_aBoard_IsNot_DirectWin()
        {
            var sut = new Board(1, 1);

            sut.WinsIfDropsIn(1)
                .Should().BeFalse();
        }
    }
}