using System.Collections.Generic;

namespace GameOfLife
{
    internal static class CellExtensions
    {
        /// <returns> Poscondition: collection of size 8.</returns>
        internal static IEnumerable<(int x, int y)> Neighbours(this (int x, int y) cell)
        {
            yield return (cell.x - 1, cell.y - 1);
            yield return (cell.x, cell.y - 1);
            yield return (cell.x + 1, cell.y - 1);
            yield return (cell.x - 1, cell.y);
            yield return (cell.x + 1, cell.y);
            yield return (cell.x - 1, cell.y + 1);
            yield return (cell.x, cell.y + 1);
            yield return (cell.x + 1, cell.y + 1);
        }
    }
}