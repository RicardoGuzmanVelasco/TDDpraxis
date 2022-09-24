using Connect4.Runtime.Domain;

namespace Connect4.Runtime.Application
{
    public class TokenDrop
    {
        readonly Board model;
        readonly BoardView view;

        public TokenDrop(Board model, BoardView view)
        {
            this.model = model;
            this.view = view;
            model.TokenDroppedInColumn += view.AddTokenIn;
        }

        public void InColumn(int column)
        {
            if(model.IsLegalMove(column))
                model.DropInColumn(column);
            else
                view.ShowColumnAsFull(column);
                
        }
    }
}