using System;
using System.Linq;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Board
    {
        enum Token { None, Red, Yellow }
        readonly Token[,] tokens;

        public event Action<int> TokenDroppedInColumn;
        
        #region Ctors
        Board(Board otherToCopy)
        {
            tokens = (Token[,])otherToCopy.tokens.Clone();
        }
        
        public Board(int rows, int columns)
        {
            Require(rows).GreaterThan(0);
            Require(columns).GreaterThan(0);
            
            tokens = new Token[rows, columns];
        }
        #endregion

        (int rows, int columns) Size => (tokens.GetLength(0), tokens.GetLength(1));
        bool IsFull => TokensDroppedCount() == Size.rows * Size.columns;
        bool HasWon => false;
        
        public void DropInColumn(int column)
        {
            Require(column).Between(1, Size.columns);
            Require(IsFullColumn(column)).False();
            Require(IsFull).False();

            if(IsFullColumn(column))
                return;
            
            DropTokenIn(column);
        }

        public bool WinsIfDropsIn(int column)
        {
            Require(column).Between(1, Size.rows);

            var simulatedDrop = new Board(this);
            simulatedDrop.DropInColumn(column);
            
            return simulatedDrop.HasWon;
        }

        #region Support methods
        bool IsFullColumn(int i)
        {
            var column = i - 1;
            var x = Enumerable.Range(0, Size.rows).Count(row => tokens[row, column] != Token.None);
            return x == Size.rows;
        }
        
        void DropTokenIn(int i)
        {
            var column = i - 1;
            var firstEmptyRow = Enumerable.Range(0, Size.rows).First(row => tokens[row, column] == Token.None);
            tokens[firstEmptyRow, column] = TokenOfThisTurn();

            TokenDroppedInColumn?.Invoke(i);
        }

        Token TokenOfThisTurn() => TokensDroppedCount() % 2 == 0 ? Token.Red : Token.Yellow;

        int TokensDroppedCount()
        {
            var result = 0;
            
            for(var i = 0; i < Size.rows; i++)
            for(var j = 0; j < Size.columns; j++)
                if(tokens[i,j] != Token.None)
                    result++;
            
            return result;
        }
        #endregion
        
        public override string ToString()
        {
            var result = "";
            for(var i = Size.rows - 1; i >= 0; i--)
            {
                for(var j = 0; j < Size.columns; j++)
                    result += tokens[i, j] switch
                    {
                        Token.None => "-",
                        Token.Red => "X",
                        Token.Yellow => "O",
                        _ => throw new NotSupportedException()
                    };
                result += "\n";
            }
            return result;
        }
    }
}