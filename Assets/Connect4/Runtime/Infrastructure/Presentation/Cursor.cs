using System.Linq;
using System.Threading.Tasks;
using Connect4.Runtime.Application;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class Cursor : MonoBehaviour, CursorView
    {
        [Inject] CursorMovement controller;
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
                controller.Left();
            else if(Input.GetKeyDown(KeyCode.RightArrow))
                controller.Right();
        }

        public Task MoveTo(int column)
        {
            var snapToThis = FindObjectsOfType<TokenSlot>().First(s => s.IsInColumn(column));
            
            var target = new Vector3
            (
                snapToThis.transform.position.x,
                transform.position.y,
                transform.position.z
            );
            transform.position = target;

            return Task.CompletedTask;
        }

        public async Task InvalidDirection(Vector2Int direction)
        {
            Debug.Log("Invalid direction " + direction);
        }
    }
}
