using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Grid_ImaginaryObject
{
    public class EndedSimulation
    {
        public void PresentSimulationResult(Point objectPositionElement)
        {
            Console.WriteLine("quit simulation and print results");

            if (CommandEngine.FailedSimulation)
            {
                Console.WriteLine("[-1, -1]");
                return;
            }

            // formatting the Point to keep the [x,y] format

            Regex regex = new Regex(@"[^0-9,]");
            var formattedCoords = regex.Replace(objectPositionElement.ToString(), "");

            Console.WriteLine($"[{formattedCoords}]");
            Console.ReadLine();
        }
    }
}
