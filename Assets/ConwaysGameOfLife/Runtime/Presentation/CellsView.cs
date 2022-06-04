using System.Collections.Generic;
using System.Threading.Tasks;
using ConwaysGameOfLife.Runtime.Application;
using ConwaysGameOfLife.Runtime.Domain;
using UnityEngine;

namespace ConwaysGameOfLife.Runtime.Presentation
{
    public class CellsView : MonoBehaviour, IGameOfLifeView
    {
        [SerializeField] GameObject cellPrefab;

        Dictionary<Vector2, SpriteRenderer> cellViews;
        GameOfLifeController controller;
        bool forwarding = true;

        void Awake()
        {
            cellViews = new Dictionary<Vector2, SpriteRenderer>();
            var glider = GameOfLife.StartWith((1, 3), (2, 3), (2, 2), (3, 2), (1, 1));
            controller = new GameOfLifeController(this, glider);
        }

        async void Start()
        {
            for(var i = 0; i < 20; i++)
                for(var j = 0; j < 20; j++)
                    SpawnCellAt(i, j);

            await controller.ShowCurrent();
            while(forwarding)
            {
                await Task.Delay(250);
                await controller.StepForward();
            }
        }

        void SpawnCellAt(int i, int j)
        {
            var coord = new Vector2(i, j);
            var go = Instantiate(cellPrefab, coord, Quaternion.identity, transform);
            
            cellViews[coord] = go.GetComponentInChildren<SpriteRenderer>();
        }
        
        #region IGameOfLifeView implementation
        public void Present(GameOfLife model)
        {
            foreach(var cellView in cellViews)
            {
                var cell = ((int)cellView.Key.x, (int)cellView.Key.y);
                cellView.Value.color = model.IsAlive(cell) ? Color.black : Color.white;
            } 
        }

        public void DisableForwarding()
        {
            forwarding = false;
        }
        #endregion
    }
}
