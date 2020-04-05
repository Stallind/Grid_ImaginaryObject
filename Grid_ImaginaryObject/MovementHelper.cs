using System.Drawing;

namespace Grid_ImaginaryObject
{
    class MovementHelper
    {
        public void ValidateObjectMovement(string direction, Point objectPositionElement, int[,] grid)
        {
            bool validMove;

            var gridFieldPoint = FindObjectElement(grid);

            if (direction == "north" || direction == "south")
            {
                validMove = objectPositionElement.X == gridFieldPoint.X;
            }
            else
            {
                validMove = objectPositionElement.Y == gridFieldPoint.Y;
            }

            if (!validMove)
            {
                CommandEngine.FailedSimulation = true;
            }
        }

        public Point FindObjectElement(int[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y] == Movement.ObjectPositionValue)
                    {
                        return new Point(x, y);
                    }
                }
            }

            return new Point(-1, -1);
        }
    }
}
