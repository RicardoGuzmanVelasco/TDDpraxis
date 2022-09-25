using System.Threading.Tasks;
using Connect4.Runtime.Application;
using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class TestPlaceholderView : MonoBehaviour, BoardView, MatchView
    {
        public async Task AddTokenIn(int column)
        {
            Debug.Log("AddTokenIn " + column);
            await Task.Delay(1000);
        }

        public async Task ShowColumnAsFull(int column)
        {
            Debug.Log("ShowColumnAsFull " + column);
            await Task.Delay(1000);
        }

        public void WarnImminentWinningMove()
        {
            Debug.Log("WarnImminentWinningMove");
        }

        public void ShowWin()
        {
            Debug.Log("ShowWin");
        }
    }
}