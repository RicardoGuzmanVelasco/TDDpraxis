using System.Threading.Tasks;
using UnityEngine;
using Cursor = Connect4.Runtime.Domain.Cursor;

namespace Connect4.Runtime.Application
{
    public class CursorMovement
    {
        readonly Cursor model;
        readonly CursorView view;

        public CursorMovement(Cursor model, CursorView view)
        {
            this.model = model;
            this.view = view;
        }

        public async Task Left() => await MoveTo(Vector2Int.left);
        public async Task Right() => await MoveTo(Vector2Int.right);

        async Task MoveTo(Vector2Int dir)
        {
            if(!model.CanGoTo(dir))
            {
                await view.InvalidDirection(dir);
                return;
            }

            model.GoTowards(dir);
            await view.MoveTo(model.InColumn);
        }
}
}