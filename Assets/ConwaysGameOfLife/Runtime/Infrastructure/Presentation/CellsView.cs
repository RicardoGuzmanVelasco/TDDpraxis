using System.Collections.Generic;
using ConwaysGameOfLife.Runtime.Application;
using ConwaysGameOfLife.Runtime.Domain;
using UnityEngine;

namespace ConwaysGameOfLife.Runtime.Infrastructure.Presentation
{
    public class CellsView : MonoBehaviour, IGameOfLifeView
    {
        [SerializeField] GameObject cellPrefab;
        [Header("Colors")]
        [SerializeField] Color aliveColor = Color.black;
        [SerializeField] Color deadColor = Color.white;

        readonly Dictionary<Vector2, SpriteRenderer> cellViews = new Dictionary<Vector2, SpriteRenderer>();

        void Awake()
        {
            for(var i = 0; i < 20; i++)
                for(var j = 0; j < 20; j++)
                    SpawnCellAt(i, j);
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
            CleanAllCellViews();
            PaintAliveCells(model);
        }

        public void DisableForwarding()
        {
            FindObjectOfType<EntryPoint>().AutoForward = false;
        }
        #endregion

        #region View rendering
        
        void PaintAliveCells(GameOfLife model)
        {
            foreach(var cell in model.AliveCells)
                RenderCellView(cell);
        }

        void CleanAllCellViews()
        {
            foreach(var cellView in cellViews)
                cellView.Value.color = deadColor;
        }

        void RenderCellView((int x, int y) cell)
        {
            var coord = new Vector2(cell.x, cell.y);

            if(!cellViews.ContainsKey(coord))
                SpawnCellAt(cell.x, cell.y);
            cellViews[coord].color = aliveColor;
        }
        #endregion
    }
}
