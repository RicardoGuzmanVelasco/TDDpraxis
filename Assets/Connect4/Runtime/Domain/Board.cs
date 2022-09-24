using System;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Board
    {
        (int rows, int columns) size;

        public event Action<int> TokenDroppedInRow;
        
        public Board(int rows, int columns)
        {
            size = (rows, columns);
        }

        public void DropInRow(int onebasedRow)
        {
            Require(onebasedRow).Between(1, size.rows);
            
            TokenDroppedInRow?.Invoke(onebasedRow);
        }
    }
}