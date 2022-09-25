using UnityEngine;

namespace Connect4.Runtime.Presentation
{
    public class TokenSlot : MonoBehaviour
    {
        [SerializeField, Min(1)] int row;
        [SerializeField, Min(1)] int col;
        
        public bool Represents(Vector2Int position) => position.x == row && position.y == col;
    }
}