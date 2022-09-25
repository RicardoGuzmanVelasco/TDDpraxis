using System.Threading.Tasks;
using Connect4.Runtime.Domain;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Application
{
    public class TokenDrop
    {
        readonly Board boardModel;
        readonly Cursor cursorModel;
        readonly BoardView boardView;

        public TokenDrop(Board boardModel, Cursor cursorModel, BoardView boardView)
        {
            this.boardModel = boardModel;
            this.cursorModel = cursorModel;
            this.boardView = boardView;
        }

        public async Task InCurrentColumn()
        {
            await InColumn(cursorModel.InColumn);
        }

        async Task InColumn(int column)
        {
            Require(boardModel.IsGameOver).False();

            if(!boardModel.IsLegalMove(column))
            {
                await boardView.ShowColumnAsFull(column);
                return;
            }
            
            boardModel.DropInColumn(column);
            await boardView.AddTokenIn(column);
        }
    }
}