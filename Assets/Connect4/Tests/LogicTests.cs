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

        [Test, Description("Each drop is from a different player, alternating turns, so 4 is 2&2")]
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

        [Test]
        public void Winning_with4Consecutive_inSameColumn()
        {
            var sut = new Board(4, 4);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(1); sut.DropInColumn(2);
            
            sut.WinsIfDropsIn(1)
                .Should().BeTrue();
        }
        
        [Test]
        public void Winning_with4Consecutive_inSameRow()
        {
            var sut = new Board(4, 4);
            sut.DropInColumn(1); sut.DropInColumn(1);
            sut.DropInColumn(2); sut.DropInColumn(2);
            sut.DropInColumn(3); sut.DropInColumn(3);
            
            sut.WinsIfDropsIn(4)
                .Should().BeTrue();
        }
        
        [Test]
        public void Winning_with4Consecutive_inDiagonal()
        {
            var sut = new Board(4, 4);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(2); sut.DropInColumn(3);
            sut.DropInColumn(3); sut.DropInColumn(4);
            sut.DropInColumn(3); sut.DropInColumn(4);
            sut.DropInColumn(4); sut.DropInColumn(1);

            sut.WinsIfDropsIn(4)
                .Should().BeTrue();
        }
    }
}