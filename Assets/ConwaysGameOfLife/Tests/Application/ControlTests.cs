using System.Threading.Tasks;
using ConwaysGameOfLife.Runtime.Application;
using ConwaysGameOfLife.Runtime.Domain;
using NSubstitute;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests.Application
{
    public class ControlTests
    {
        [Test]
        public async Task ShowEmptyGame()
        {
            var mockView = Substitute.For<IGameOfLifePresenter>();
            var sut = new GameAdvance(mockView, GameOfLife.Empty);
            await sut.ShowCurrent();
            
            mockView.Received(1).Present(GameOfLife.Empty);
        }

        [Test]
        public async Task ShowStartingGame()
        {
            var mockView = Substitute.For<IGameOfLifePresenter>();
            var sut = new GameAdvance(mockView, GameOfLife.StartWith((78, -11)));
            await sut.ShowCurrent();
            
            mockView.Received(1).Present(GameOfLife.StartWith((78, -11)));
        }
    }
}