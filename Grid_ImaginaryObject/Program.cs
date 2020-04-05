namespace Grid_ImaginaryObject
{
    class Program
    {
        static void Main(string[] args)
        {
           Initialize();
        }

        static void Initialize()
        {
            int[,] grid = UserInput.GenerateGrid();

            UserInput.RegisterInitialObjectPosition(grid);

            var commandQueue = UserInput.RegisterCommands();

            CommandEngine.ExecuteCommandQueue(commandQueue, grid);
        }
    }
}
