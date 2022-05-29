using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public record GameOfLife
    {
        public static GameOfLife Empty => new GameOfLife();
        public IEnumerable<(int x, int y)> AliveCells { get; }

        GameOfLife(params (int x, int y)[] aliveCells)
        {
            AliveCells = aliveCells ?? Enumerable.Empty<(int x, int y)>();
        }

        public static GameOfLife StartWith(params (int x, int y)[] aliveCells)
        {
            return new GameOfLife(aliveCells);
        }

        public GameOfLife Forward(int stepsInTime = 1)
        {
            return Empty;
        }
    }
}