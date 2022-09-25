using Connect4.Runtime.Domain;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.EntryPoint
{
    public class DomainBoardPrinter : MonoBehaviour
    {
        [Inject] Board domainBoard;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Tab))
                Debug.Log("Printing board, see below: \n" + domainBoard);
        }
    }
}