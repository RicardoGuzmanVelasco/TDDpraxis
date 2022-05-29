using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public record GameOfLife
    {
        public static GameOfLife Empty => new GameOfLife();
        public IEnumerable<(int x, int y)> AliveCells { get; }

        #region Ctors
        GameOfLife(params (int x, int y)[] aliveCells)
        {
            AliveCells = aliveCells ?? Enumerable.Empty<(int x, int y)>();
        }

        public static GameOfLife StartWith(params (int x, int y)[] aliveCells)
        {
            return new GameOfLife(aliveCells);
        }
        #endregion

        public GameOfLife Forward()
        {
            var nextGeneration = AliveCells.Where(cell => AliveNeighboursOf(cell) is 2 or 3);
            return new GameOfLife(nextGeneration.ToArray());
        }

        #region Support methods
        int AliveNeighboursOf((int x, int y) cell)
        {
            var neighbours = cell.Neighbours();
            return neighbours.Count(neighbour => AliveCells.Contains(neighbour));
        }

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            if(Equals(Empty)) 
                builder.Append("Empty");
            
            foreach(var alive in AliveCells)
                builder.Append(alive);

            return true;
        }
        #endregion
    }
}