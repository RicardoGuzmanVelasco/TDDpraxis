using Connect4.Runtime.Application;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class CommitDropInput : MonoBehaviour
    {
        [Inject] TokenDrop controller;
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                controller.InCurrentColumn();
        }
    }
}