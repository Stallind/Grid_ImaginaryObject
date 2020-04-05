using System;
using System.Collections.Generic;
using System.Linq;

namespace Grid_ImaginaryObject
{
    class UserInput
    {
        public static int[,] GenerateGrid()
        {
            Console.Write($"Enter grid size (eg. 4,4): ");
            var gridSize = Console.ReadLine();
            var gridCoords = gridSize.Split(',').Select(Int32.Parse).ToArray();
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

        public static void RegisterInitialObjectPosition(int[,] grid)
        {
            Console.Write("Object starting position: ");
            var objectInput = Console.ReadLine();

            //Reading the instructions, I assume you want the input to be typed in this format: x,y

            var splitInput = objectInput.Split(',').Select(Int32.Parse).ToArray();
            var objectX = splitInput[0];
            var objectY = splitInput[1];

            Movement.ObjectPositionValue = grid[objectX, objectY];

            var objectStartCords = objectX + objectY.ToString().Insert(0, ",");
            Console.WriteLine($"Object placed at: {objectStartCords} with the ObjectPositionValue: {Movement.ObjectPositionValue}");
        }

        public static List<int> RegisterCommands()
        {
            Console.Write($"{Environment.NewLine}Enter command input: ");

            // Same thing here, commands input format follow the instuction example: x,x,x,x,x,x

            var commands = Console.ReadLine();
            var commandQueue = commands.Split(',').Select(Int32.Parse).ToList();

            return commandQueue;
        }
    }
}
