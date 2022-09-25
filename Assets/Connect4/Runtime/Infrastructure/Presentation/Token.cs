using UnityEngine;
using static RGV.DesignByContract.Runtime.Contract;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Token : MonoBehaviour
    {
        [SerializeField] Color player1;
        [SerializeField] Color player2;

        public void AssingToPlayer(int player)
        {
            Require(player).Between(1, 2);

            GetComponent<SpriteRenderer>().color = player switch
            {
                1 => player1,
                2 => player2,
                _ => Color.white
            };
        }
    }
}