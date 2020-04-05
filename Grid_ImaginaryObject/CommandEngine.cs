using System.Collections.Generic;

namespace Grid_ImaginaryObject
{
    class CommandEngine
    {
        public static bool FailedSimulation { get; set; }

        public static void ExecuteCommandQueue(List<int> commandQueue, int[,] grid)
        {
            var direction = "north";
            var move = new Movement();
            var result = new EndedSimulation();
            var helper = new MovementHelper();
            
            foreach (var command in commandQueue)
            {
                var objectPositionElement = helper.FindObjectElement(grid);
                
                switch (command)
                {
                    case 0:
                        result.PresentSimulationResult(objectPositionElement);
                        break;
                    case 1:
                        move.MoveForward(direction, grid, objectPositionElement);
                        break;
                    case 2:
                        move.MoveBackwards(direction, grid, objectPositionElement);
                        break;
                    case 3:
                        direction = move.TurnClockwise(direction);
                        break;
                    case 4:
                        direction = move.TurnCounterClockwise(direction);
                        break;
                }
            }
        }
    }
}
