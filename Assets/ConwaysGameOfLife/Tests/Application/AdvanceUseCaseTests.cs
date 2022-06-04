using System.Threading.Tasks;
using ConwaysGameOfLife.Runtime.Application;
using ConwaysGameOfLife.Runtime.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests.Application
{
    public class AdvanceUseCaseTests
    {
        [Test]
        public async Task ShowEmptyGame()
        {
            var mockView = Substitute.For<IGameOfLifeView>();
            var sut = new GameOfLifeController(mockView, GameOfLife.Empty);
            await sut.ShowCurrent();
            
            mockView.Received(1).Present(GameOfLife.Empty);
        }

        [Test]
        public async Task ShowStartingGame()
        {
            var mockView = Substitute.For<IGameOfLifeView>();
            var sut = new GameOfLifeController(mockView, GameOfLife.StartWith((0, 0)));
            await sut.ShowCurrent();
            
            mockView.Received(1).Present(GameOfLife.StartWith((0, 0)));
        }

        [Test]
        public async Task Forward_WhenStill_DisablesForwarding()
        {
            var mockView = Substitute.For<IGameOfLifeView>();
            var sut = new GameOfLifeController(mockView, GameOfLife.Empty);
            await sut.StepForward();
            
            mockView.Received(1).DisableForwarding();
        }
    }
}