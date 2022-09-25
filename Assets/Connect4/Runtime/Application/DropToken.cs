using System.Threading.Tasks;
using Connect4.Runtime.Domain;
using static RGV.DesignByContract.Runtime.Contract;

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
        }

        public async Task InColumn(int column)
        {
            Require(model.IsGameOver).False();

            if(!model.IsLegalMove(column))
            {
                await view.ShowColumnAsFull(column);
                return;
            }
            
            model.DropInColumn(column);
            await view.AddTokenIn(column);
        }
    }
}