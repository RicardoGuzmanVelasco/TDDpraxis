namespace Connect4.Runtime.Application
{
    public interface BoardView
    {
        void AddTokenIn(int column);
        void ShowColumnAsFull(int column);
    }
}