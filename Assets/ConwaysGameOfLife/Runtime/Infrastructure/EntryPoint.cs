using System.Threading.Tasks;
using ConwaysGameOfLife.Runtime.Application;
using ConwaysGameOfLife.Runtime.Domain;
using ConwaysGameOfLife.Runtime.Infrastructure.Presentation;
using UnityEngine;

namespace ConwaysGameOfLife.Runtime.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        GameOfLifeController controller;
        public bool AutoForward { get; set; } = true;

        async void Start()
        {
            IGameOfLifeView view = FindObjectOfType<CellsView>();
            var glider = GameOfLife.StartWith((1, 3), (2, 3), (2, 2), (3, 2), (1, 1));
            controller = new GameOfLifeController(view, glider);
            
            await controller.ShowCurrent();
            
            while(AutoForward)
            {
                await Task.Delay(250);
                await controller.StepForward();
            }
        }
    }
}