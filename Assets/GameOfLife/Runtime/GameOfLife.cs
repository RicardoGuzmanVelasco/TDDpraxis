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
            AliveCells = new HashSet<(int x, int y)>(aliveCells);
        }

        public static GameOfLife StartWith(params (int x, int y)[] aliveCells)
        {
            return new GameOfLife(aliveCells);
        }
        #endregion

        public bool IsAlive((int x, int y) cell) => AliveCells.Contains(cell);

        public GameOfLife Forward()
        {
            var survivors = AliveCells.Where(Survives);
            var revivors = AliveCells.SelectMany(Neighbours).Where(Revives);
            
            var nextGeneration = survivors.Concat(revivors).ToArray();
            return new GameOfLife(nextGeneration);
        }

        #region Support methods
        bool Revives((int x, int y) cell)
        {
            return AliveCells.SelectMany(Neighbours).Count(c => c.Equals(cell)) == 3;
        }
        bool Survives((int x, int y) cell)
        {
            return AliveNeighboursOf(cell) is 2 or 3;
        }
        
        int AliveNeighboursOf((int x, int y) cell)
        {
            var neighbours = Neighbours(cell);
            return neighbours.Count(neighbour => AliveCells.Contains(neighbour));
        }

        static IEnumerable<(int x, int y)> Neighbours((int x, int y) cell)
        {
            return cell.AdjacentsWithDiagonals();
        }
        #endregion

        #region Equality
        public virtual bool Equals(GameOfLife other)
        {
            return other is not null && AliveCells.SequenceEqual(other.AliveCells);
        }

        public override int GetHashCode()
        {
            return (AliveCells != null ? AliveCells.GetHashCode() : 0);
        }
        #endregion
        
        #region Formatting
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