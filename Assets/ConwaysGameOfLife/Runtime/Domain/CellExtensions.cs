using System.Collections.Generic;

namespace ConwaysGameOfLife.Runtime.Domain
{
    internal static class CellExtensions
    {
        /// <returns> Poscondition: collection of size 8.</returns>
        internal static IEnumerable<(int x, int y)> AdjacentsWithDiagonals(this (int x, int y) cell)
        {
            yield return (cell.x - 1, cell.y - 1);
            yield return (cell.x + 0, cell.y - 1);
            yield return (cell.x + 1, cell.y - 1);
            yield return (cell.x - 1, cell.y + 0);
            yield return (cell.x + 1, cell.y + 0);
            yield return (cell.x - 1, cell.y + 1);
            yield return (cell.x + 0, cell.y + 1);
            yield return (cell.x + 1, cell.y + 1);
        }
    }
}