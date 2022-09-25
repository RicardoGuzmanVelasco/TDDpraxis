using System.Threading.Tasks;
using Connect4.Runtime.Application;
using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class SlotsActAsTokensThemselves : MonoBehaviour, BoardView
    {
        public async Task AddTokenIn(int column)
        {
            Debug.Log("AddTokenIn " + column);
        }

        public async Task ShowColumnAsFull(int column)
        {
            Debug.Log("ShowColumnAsFull " + column);
        }
    }
}