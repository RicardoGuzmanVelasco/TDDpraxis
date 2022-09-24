using Connect4.Runtime.Domain;

namespace Connect4.Runtime.Application
{
    public class TokenDrop
    {
        readonly Board model;

        public TokenDrop(Board model, BoardView view)
        {
            this.model = model;
            model.TokenDroppedInColumn += view.AddTokenIn;
        }

        public void InColumn(int column)
        {
            model.DropInColumn(column);
        }
    }
}