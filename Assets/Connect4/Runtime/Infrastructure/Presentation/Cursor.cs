using System.Linq;
using System.Threading.Tasks;
using Connect4.Runtime.Application;
using DG.Tweening;
using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class Cursor : MonoBehaviour, CursorView
    {
        public Task MoveTo(int column)
        {
            var snapToThis = FindObjectsOfType<TokenSlot>().First(s => s.Col == column);
            transform.DOMoveX(snapToThis.transform.position.x, .3f).SetEase(Ease.OutBounce);

            return Task.CompletedTask;
        }

        public Task InvalidDirection(Vector2Int direction)
        {
            WarnRedColor();
            MagnetSnapTowardsInvalidDirection(direction);

            return Task.CompletedTask;
        }

        void MagnetSnapTowardsInvalidDirection(Vector2Int direction)
        {
            transform.DOShakePosition
            (
                duration: .15f,
                strength: new Vector3(direction.x * .05f, 0),
                vibrato: 25,
                randomness: 0,
                snapping: false,
                fadeOut: false
            );
        }

        void WarnRedColor()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.DOColor
            (
                endValue: Color.red,
                duration: .15f
            ).SetLoops(2, LoopType.Yoyo);
        }
    }
}
