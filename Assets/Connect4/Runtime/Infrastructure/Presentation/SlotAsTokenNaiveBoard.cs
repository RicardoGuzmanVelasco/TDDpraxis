using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connect4.Runtime.Application;
using DG.Tweening;
using UnityEngine;

namespace Connect4.Runtime.Infrastructure.Presentation
{
    public class SlotAsTokenNaiveBoard : MonoBehaviour, BoardView
    {
        public async Task AddTokenIn(int column)
        {
            var slots = SlotsInColumn(column);
            
            
        }

        public async Task ShowColumnAsFull(int column)
        {
            foreach (var slot in SlotsInColumn(column))
                slot.transform.DOShakePosition
                (
                    duration: .15f,
                    strength: Vector3.down * .05f,
                    vibrato: 25,
                    randomness: 0,
                    snapping: false,
                    fadeOut: false
                );

            await Task.CompletedTask;
        }

        static IEnumerable<TokenSlot> SlotsInColumn(int column)
        {
            return FindObjectsOfType<TokenSlot>().Where(s => s.IsInColumn(column));
        }
    }
}