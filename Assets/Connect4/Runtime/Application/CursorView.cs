using System.Threading.Tasks;
using UnityEngine;

namespace Connect4.Runtime.Application
{
    public interface CursorView
    {
        Task MoveTo(int column);
        Task InvalidDirection(Vector2Int direction);
    }
}