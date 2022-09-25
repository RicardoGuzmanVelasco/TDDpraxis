using Connect4.Runtime.Application;
using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class TestPlaceholderView : MonoBehaviour, MatchView
    {
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