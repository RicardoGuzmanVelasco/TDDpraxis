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

        bool IsOver => IsFull || HasWon;
        bool IsFull => TokensDroppedCount() == Size.rows * Size.columns;
        bool HasWon => HasWonByColumn() || HasWonByRow() || HasWonByDiagonal();
        (int rows, int columns) Size => (tokens.GetLength(0), tokens.GetLength(1));
        
        public void DropInColumn(int column)
        {
            Require(column).Between(1, Size.columns);
            Require(IsFullColumn(column)).False();
            Require(IsOver).False();

            if(IsFullColumn(column))
                return;
            
            DropTokenIn(column);
        }

        public bool WinsIfDropsIn(int column)
        {
            Require(column).Between(1, Size.rows);
            Require(IsFullColumn(column)).False();
            Require(IsOver).False();

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

        bool HasWonByColumn()
        {
            for(var i = 0; i < Size.columns; i++)
                if(HasWonByColumn(i))
                    return true;
            
            return false;
            
            bool HasWonByColumn(int column)
            {
                var token = tokens[0, column];
                var count = 0;
            
                for(var i = 0; i < Size.rows; i++)
                {
                    if(tokens[i, column] == token)
                        count++;
                    else
                    {
                        count = 0;
                        token = tokens[i, column];
                    }
                
                    if(count == 4 && token != Token.None)
                        return true;
                }

                return false;
            }
        }

        bool HasWonByRow()
        {
            for(var i = 0; i < Size.rows; i++)
                if(HasWonByRow(i))
                    return true;
            
            return false;
            
            bool HasWonByRow(int row)
            {
                var token = tokens[row, 0];
                var count = 0;
            
                for(var i = 0; i < Size.columns; i++)
                {
                    if(tokens[row, i] == token)
                        count++;
                    else
                    {
                        count = 0;
                        token = tokens[row, i];
                    }
                
                    if(count == 4 && token != Token.None)
                        return true;
                }

                return false;
            }
        }
        
        bool HasWonByDiagonal()
        {
            for(var i = 0; i < Size.rows; i++)
                for(var j = 0; j < Size.columns; j++)
                    if(HasWonByDiagonal(i, j))
                        return true;
            
            return false;
            
            bool HasWonByDiagonal(int row, int column)
            {
                var token = tokens[row, column];
                var count = 0;
            
                for(var i = 0; i < Size.rows; i++)
                {
                    if(row + i >= Size.rows || column + i >= Size.columns)
                        break;
                
                    if(tokens[row + i, column + i] == token)
                        count++;
                    else
                    {
                        count = 0;
                        token = tokens[row + i, column + i];
                    }
                
                    if(count == 4 && token != Token.None)
                        return true;
                }

                return false;
            }
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