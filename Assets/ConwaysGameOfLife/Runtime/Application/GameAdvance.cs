using System.Threading.Tasks;

namespace ConwaysGameOfLife.Runtime.Application
{
    public interface IGameOfLifeView
    {
        void Present(Domain.GameOfLife model);
        void DisableForwarding();
    }
    
    public class GameAdvance
    {
        readonly IGameOfLifeView view;
        Domain.GameOfLife game;

        public GameAdvance(IGameOfLifeView view, Domain.GameOfLife game)
        {
            this.view = view;
            this.game = game;
        }

        public async Task StepForward()
        {
            game = game.Forward();
            
            if(game.IsStill())
                view.DisableForwarding();
            
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