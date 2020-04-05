using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Grid_ImaginaryObject
{
    class Program
    {
        public static int ObjectPositionValue { get; set; }
        public static bool FailedSimulation { get; set; }
        static void Main(string[] args)
        {
            int[,] grid = GenerateGrid();

            RegisterInitialObjectPosition(grid);

            var commandQueue = RegisterCommands();
            ExecuteCommandQueue(commandQueue, grid);
        }

        private static void ExecuteCommandQueue(List<int> commandQueue, int[,] grid)
        {
            var direction = "north";

            foreach (var command in commandQueue)
            {
                var objectPositionElement = FindObjectElement(grid);

                switch (command)
                {
                    case 0:
                        PresentSimulationResult(objectPositionElement);
                        break;
                    case 1:
                        MoveForward(direction, grid);
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

        private static void PresentSimulationResult(Point objectPositionElement)
        {
            Console.WriteLine("quit simulation and print results");

            if (FailedSimulation)
            {
                Console.WriteLine("[-1, -1]");
                return;
            }

            Regex regex = new Regex(@"[\D]");
            var justNumbers = regex.Replace(objectPositionElement.ToString(), "");
            justNumbers.Split(',').Select(int.Parse).ToArray();
            var x = justNumbers[0];
            var y = justNumbers[1];
            string addCommaToCords = x + y.ToString().Insert(0, ", ");
            string formattedCords = $"[{addCommaToCords}]";

            // formatting the Point to keep the [x,y] format

            Console.WriteLine(formattedCords);
            Console.ReadLine();
        }

        private static Point FindObjectElement(int[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y] == ObjectPositionValue)
                    {
                        return new Point(x, y);
                    }
                }
            }

            return new Point(-1, -1);
        }

        private static void MoveForward(string direction, int[,] grid)
        {
            switch (direction)
            {
                case "north":
                    ObjectPositionValue -= 1;
                    Console.WriteLine($"moving forward north {ObjectPositionValue}");
                    break;
                case "east":
                    ObjectPositionValue += grid.GetLength(0);
                    Console.WriteLine($"moving forward east {ObjectPositionValue}");
                    break;
                case "south":
                    ObjectPositionValue += 1;
                    Console.WriteLine($"moving forward south {ObjectPositionValue}");
                    break;
                case "west":
                    ObjectPositionValue -= grid.GetLength(0);
                    Console.WriteLine($"moving forward west {ObjectPositionValue}");
                    break;
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
