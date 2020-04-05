using System;
using System.Linq;

namespace Grid_ImaginaryObject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = GenerateGrid();

            foreach (var value in grid)
            {
                Console.WriteLine(value);
            }
        }

        private static int[,] GenerateGrid()
        {
            Console.Write($"Enter grid size (eg. 4,4): ");
            var gridSize = Console.ReadLine();
            var gridCoords = gridSize.Split(',').Select(int.Parse).ToArray();
            var gridWidth = gridCoords[0];
            var gridHeight = gridCoords[1];

            int[,] grid = new int[gridWidth, gridHeight];

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[x, y] = gridWidth * x + y;
                }
            }

            return grid;
        }
    }
}
