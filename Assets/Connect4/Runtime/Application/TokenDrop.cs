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
        readonly MatchView matchView;

        public TokenDrop(Board boardModel, Cursor cursorModel, BoardView boardView, MatchView matchView = null)
        {
            this.boardModel = boardModel;
            this.cursorModel = cursorModel;
            this.boardView = boardView;
            this.matchView = matchView;
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

            var winningMove = boardModel.WinsIfDropsIn(column);
            if(winningMove)
                matchView?.WarnImminentWinningMove();
            
            boardModel.DropInColumn(column);
            await boardView.AddTokenIn(column);

            if(winningMove)
                matchView?.ShowWin();
        }
    }
}