using System.Threading.Tasks;

namespace Connect4.Runtime.Application
{
    public interface MatchView
    {
        void WarnImminentWinningMove();
        void ShowWin();
    }
    public interface BoardView
    {
        Task AddTokenIn(int column);
        Task ShowColumnAsFull(int column);
    }
}