using System.Collections.Generic;
using UnityEngine;

namespace ConwaysGameOfLife.Runtime.Presentation
{
    public class CellsView : MonoBehaviour
    {
        [SerializeField] GameObject cellPrefab;

        Dictionary<Vector2, SpriteRenderer> cells;

        void Awake()
        {
            cells = new Dictionary<Vector2, SpriteRenderer>();
        }

        void Start()
        {
            for(var i = 0; i < 20; i++)
                for(var j = 0; j < 20; j++)
                    SpawnCellAt(i, j);
        }

        void SpawnCellAt(int i, int j)
        {
            var coord = new Vector2(i, j);
            var go = Instantiate(cellPrefab, coord, Quaternion.identity);
            
            cells[coord] = go.GetComponent<SpriteRenderer>();
        }
    }
}
