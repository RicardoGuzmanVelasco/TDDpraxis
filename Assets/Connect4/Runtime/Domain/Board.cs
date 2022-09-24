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
            Require(rows).GreaterThan(0);
            Require(columns).GreaterThan(0);
            
            size = (rows, columns);
        }
        
        bool IsFull => tokensPerColumn.Count == size.rows * size.columns;
        
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

            return false;
        }
        
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
    }
}