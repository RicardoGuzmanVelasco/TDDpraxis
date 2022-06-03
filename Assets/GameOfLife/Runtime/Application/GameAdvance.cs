using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOfLife.Runtime.Application
{
    public interface IDisplayView
    {
        Task Render(IEnumerable<(int x, int y)> onCoords);
    }
    
    public class GameAdvance
    {
        readonly IDisplayView view;
        Domain.GameOfLife game;

        public GameAdvance(IDisplayView view, Domain.GameOfLife game)
        {
            this.view = view;
            this.game = game;
        }

        public async Task StepForward()
        {
            game = game.Forward();
            await ShowCurrent();
        }

        public async Task ShowCurrent()
        {
            await view.Render(game.AliveCells);
        }
    }
}