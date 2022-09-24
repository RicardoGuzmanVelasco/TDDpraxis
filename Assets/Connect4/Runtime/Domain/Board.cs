using System;
using System.Collections.Generic;
using System.Linq;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Board
    {
        readonly (int rows, int columns) size;
        readonly Dictionary<int, int> tokensPerColumn = new();

        public event Action<int> TokenDroppedInColumn;
        
        #region Ctors
        public Board(int rows, int columns)
        {
            Require(rows).GreaterThan(0);
            Require(columns).GreaterThan(0);
            
            size = (rows, columns);
        }

        Board(Board otherToCopy)
        {
            size = otherToCopy.size;
            tokensPerColumn = new Dictionary<int, int>(otherToCopy.tokensPerColumn);
        }
        #endregion
        
        public bool IsFull => tokensPerColumn.Values.Sum() == size.rows * size.columns;
        bool HasWon => false;
        
        public void DropInColumn(int column)
        {
            Require(column).Between(1, size.rows);
            Require(IsFullColumn(column)).False();
            Require(IsFull).False();

            InitializeColumn(column);
            if(IsFullColumn(column))
                return;
            
            DropTokenIn(column);
        }

        public bool WinsIfDropsIn(int column)
        {
            Require(column).Between(1, size.rows);

            var simulatedDrop = new Board(this);
            simulatedDrop.DropInColumn(column);
            
            return simulatedDrop.HasWon;
        }

        #region Support methods
        void InitializeColumn(int i)
        {
            if(!tokensPerColumn.ContainsKey(i))
                tokensPerColumn[i] = 0;
        }

        bool IsFullColumn(int i)
        {
            InitializeColumn(i);
            return tokensPerColumn[i] >= size.rows;
        }
        
        void DropTokenIn(int i)
        {
            tokensPerColumn[i]++;
            TokenDroppedInColumn?.Invoke(i);
        }
        #endregion
    }
}