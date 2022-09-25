using RGV.DesignByContract.Runtime;
using UnityEngine;

namespace Connect4.Runtime.Domain
{
    public class Cursor
    {
        readonly int maxColumn;
        public int InColumn { get; private set; }

        public Cursor(int columns, int beginIn = 1)
        {
            maxColumn = columns;
            InColumn = beginIn;
        }

        public bool CanGoTo(Vector2Int horizontalDirection)
        {
            Contract.Require(horizontalDirection == Vector2Int.left || horizontalDirection == Vector2Int.right).True();
            
            var desiredColumn = InColumn + horizontalDirection.x;
            return desiredColumn >= 1 && desiredColumn <= maxColumn;
        }

        public void GoTo(Vector2Int horizontalDirection)
        {
            Contract.Require(CanGoTo(horizontalDirection)).True();
            
            InColumn += horizontalDirection.x;
        }
    }
}