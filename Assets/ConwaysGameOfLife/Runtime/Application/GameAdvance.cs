using System.Threading.Tasks;

namespace ConwaysGameOfLife.Runtime.Application
{
    public interface IGameOfLifePresenter
    {
        void Present(Domain.GameOfLife model);
    }
    
    public class GameAdvance
    {
        readonly IGameOfLifePresenter view;
        Domain.GameOfLife game;

        public GameAdvance(IGameOfLifePresenter view, Domain.GameOfLife game)
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
            // NSubstitute not working. https://stackoverflow.com/questions/30996024/check-calls-received-for-async-method
            view.Present(game);
            await Task.CompletedTask;
        }
    }
}