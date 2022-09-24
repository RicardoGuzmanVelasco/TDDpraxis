using System;
using System.Collections.Generic;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Board
    {
        readonly (int rows, int columns) size;
        readonly Dictionary<int, int> tokensPerColumn = new();

        public event Action<int> TokenDroppedInColumn;
        
        public Board(int rows, int columns)
        {
            size = (rows, columns);
        }

        public void DropInColumn(int columnBase1)
        {
            Require(columnBase1).Between(1, size.rows);

            InitializeColumn(columnBase1);
            if(IsFullColumn(columnBase1))
                return;
            
            DropTokenIn(columnBase1);
        }
        
        void InitializeColumn(int i)
        {
            if(!tokensPerColumn.ContainsKey(i))
                tokensPerColumn[i] = 0;
        }

        bool IsFullColumn(int i)
        {
            return tokensPerColumn[i] >= size.rows;
        }
        
        void DropTokenIn(int i)
        {
            tokensPerColumn[i]++;
            TokenDroppedInColumn?.Invoke(i);
        }
    }
}