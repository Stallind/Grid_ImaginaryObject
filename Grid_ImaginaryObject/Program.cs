using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Grid_ImaginaryObject
{
    class Program
    {
        public static int ObjectPositionValue { get; set; }
        static void Main(string[] args)
        {
            int[,] grid = GenerateGrid();

            RegisterInitialObjectPosition(grid);

            var commandQueue = RegisterCommands();
            ExecuteCommandQueue(commandQueue);
        }

        private static void ExecuteCommandQueue(List<int> commandQueue)
        {
            foreach (var command in commandQueue)
            {
                switch (command)
                {
                    case 0:
                        Console.WriteLine("quit simulation and print results");
                        break;
                    case 1:
                        Console.WriteLine("move forward one step");
                        break;
                    case 2:
                        Console.WriteLine("move backwards one step");
                        break;
                    case 3:
                        Console.WriteLine("rotate clockwise 90 degrees (eg north to east)");
                        break;
                    case 4:
                        Console.WriteLine("rotate counter clockwise (eg west to south)");
                        break;
                }
            }
        }

        private static List<int> RegisterCommands()
        {
            Console.Write($"{Environment.NewLine}Enter command input: ");

            // Same thing here, commands input format follow the instuction example: x,x,x,x,x,x

            var commands = Console.ReadLine();
            var commandQueue = commands.Split(',').Select(int.Parse).ToList();

            return commandQueue;
        }

        private static void RegisterInitialObjectPosition(int[,] grid)
        {
            Console.Write("Object starting position: ");
            var objectInput = Console.ReadLine();

            //Reading the instructions, I assume you want the input to be typed in this format: x,y

            var splitInput = objectInput.Split(',').Select(int.Parse).ToArray();
            var objectX = splitInput[0];
            var objectY = splitInput[1];

            ObjectPositionValue = grid[objectX, objectY];

            var objectStartCords = objectX + objectY.ToString().Insert(0, ",");
            Console.WriteLine($"Object placed at: {objectStartCords} with the ObjectPositionValue: {ObjectPositionValue}");
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
