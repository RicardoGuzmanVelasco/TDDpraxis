using UnityEngine;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Domain
{
    public class Cursor
    {
        readonly int maxColumn;
        public int InColumn { get; private set; }

        public Cursor(int columns, int beginIn = 1)
        {
            Require(columns).Positive();
            Require(beginIn).Between(1, columns);
            
            maxColumn = columns;
            InColumn = beginIn;
        }

        public bool CanGoTo(Vector2Int horizontalDirection)
        {
            Require(horizontalDirection == Vector2Int.left ||
                    horizontalDirection == Vector2Int.right).True();
            
            var desiredColumn = InColumn + horizontalDirection.x;
            return desiredColumn >= 1 && desiredColumn <= maxColumn;
        }

        public void GoTowards(Vector2Int horizontalDirection)
        {
            Require(CanGoTo(horizontalDirection)).True();
            
            InColumn += horizontalDirection.x;
        }
    }
}