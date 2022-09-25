using Connect4.Runtime.Domain;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Cursor = Connect4.Runtime.Domain.Cursor;

namespace Connect4.Tests
{
    public class LogicTests
    {
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

        [Test, Description("Regression")]
        public void Winning_with4Consecutive_inSameRow_NotAtLeftEdge_ofTheBoard()
        {
            var sut = new Board(2, 5);
            sut.DropInColumn(2); sut.DropInColumn(2);
            sut.DropInColumn(3); sut.DropInColumn(3);
            sut.DropInColumn(4); sut.DropInColumn(4);

            sut.WinsIfDropsIn(5)
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

        [Test]
        public void LegalMove_IfNeitherFullColumnNorGameOver()
        {
            var sut = new Board(1, 1);

            sut.IsLegalMove(1)
                .Should().BeTrue();
        }

        [Test]
        public void NotLegalMove_IfFullColumn()
        {
            var sut = new Board(1, 1);
            sut.DropInColumn(1);

            sut.IsLegalMove(1)
                .Should().BeFalse();
        }

        [Test]
        public void NotLegalMove_IfGameOver()
        {
            var sut = new Board(4, 2);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(1); sut.DropInColumn(2);
            sut.DropInColumn(1);
            
            sut.IsLegalMove(2)
                .Should().BeFalse();
        }

        [Test]
        public void Cursor_StartsAt_Column1()
        {
            var sut = new Cursor(columns: 2);
            
            sut.InColumn
                .Should().Be(1);
        }

        [Test]
        public void Cursor_CannotGoToLeft_AfterStart()
        {
            var sut = new Cursor(columns: 2);
            
            sut.CanGoTo(Vector2Int.left)
                .Should().BeFalse();
        }

        [Test]
        public void Cursor_CanGoToDirection_WhenNotInTheEdge()
        {
            var sut = new Cursor(columns: 2);
            
            sut.CanGoTo(Vector2Int.right)
                .Should().BeTrue();
        }

        [Test]
        public void Cursor_CannotExceed_Columns()
        {
            var sut = new Cursor(columns: 2);
            sut.GoTowards(Vector2Int.right);

            sut.CanGoTo(Vector2Int.right)
                .Should().BeFalse();
        }

        [Test]
        public void Cursor_Moves()
        {
            var sut = new Cursor(columns: 5);
            sut.GoTowards(Vector2Int.right);
            sut.GoTowards(Vector2Int.right);
            sut.GoTowards(Vector2Int.right);

            sut.InColumn
                .Should().Be(4);
        }
    }
}