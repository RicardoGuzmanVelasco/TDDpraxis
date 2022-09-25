using Connect4.Runtime.Application;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class MoveCursorInput : MonoBehaviour
    {
        [Inject] CursorMovement controller;
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
                controller.Left();
            else if(Input.GetKeyDown(KeyCode.RightArrow))
                controller.Right();
        }
    }
}