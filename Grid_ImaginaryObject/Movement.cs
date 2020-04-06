using System;
using System.Drawing;

namespace Grid_ImaginaryObject
{
    public class Movement
    {
        public static int ObjectPositionValue { get; set; }
        public void MoveForward(string direction, int[,] grid, Point objectPositionElement)
        {
            var helper = new MovementHelper();

            switch (direction)
            {
                case "north":
                    ObjectPositionValue -= 1;
                    objectPositionElement.Y -= 1;
                    break;

                case "east":
                    ObjectPositionValue += grid.GetLength(0);
                    objectPositionElement.X += 1;
                    break;

                case "south":
                    ObjectPositionValue += 1;
                    objectPositionElement.Y += 1;
                    break;

                case "west":
                    ObjectPositionValue -= grid.GetLength(0);
                    objectPositionElement.X -= 1;
                    break;
            }
            helper.ValidateObjectMovement(direction, objectPositionElement, grid);
        }

        public void MoveBackwards(string direction, int[,] grid, Point objectPositionElement)
        {
            var helper = new MovementHelper();
            switch (direction)
            {
                case "north":
                    ObjectPositionValue += 1;
                    objectPositionElement.Y -= 1;
                    break;

                case "east":
                    ObjectPositionValue -= grid.GetLength(0);
                    objectPositionElement.X += 1;
                    break;

                case "south":
                    ObjectPositionValue -= 1;
                    objectPositionElement.Y += 1;
                    break;

                case "west":
                    ObjectPositionValue += grid.GetLength(0);
                    objectPositionElement.X -= 1;
                    break;
            }
            helper.ValidateObjectMovement(direction, objectPositionElement, grid);
        }

        public string TurnClockwise(string direction)
        {
            Console.WriteLine("rotate clockwise 90 degrees (eg north to east)");

            return direction switch
            {
                "north" => "east",
                "east" => "south",
                "south" => "west",
                "west" => "north",
                _ => null
            };
        }

        public string TurnCounterClockwise(string direction)
        {
            Console.WriteLine("rotate counter clockwise (eg west to south)");

            return direction switch
            {
                "north" => "west",
                "west" => "south",
                "south" => "east",
                "east" => "north",
                _ => null
            };
        }
    }
}
