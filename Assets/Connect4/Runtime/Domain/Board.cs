using System;
using System.Collections.Generic;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Board
    {
        (int rows, int columns) size;
        Dictionary<int, int> tokensPerColumn = new();

        public event Action<int> TokenDroppedInColumn;
        
        public Board(int rows, int columns)
        {
            size = (rows, columns);
        }

        public void DropInColumn(int onebasedRow)
        {
            Require(onebasedRow).Between(1, size.rows);

            if(tokensPerColumn.ContainsKey(onebasedRow))
                tokensPerColumn[onebasedRow]++;
            else
                tokensPerColumn[onebasedRow] = 1;
            
            if(tokensPerColumn[onebasedRow] < size.rows)
                TokenDroppedInColumn?.Invoke(onebasedRow);
        }
    }
}