using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class TokenSlot : MonoBehaviour
    {
        [SerializeField, Min(1)] int row;
        [SerializeField, Min(1)] int col;
        
        public int Row => row;
        public int Col => col;
    }
}