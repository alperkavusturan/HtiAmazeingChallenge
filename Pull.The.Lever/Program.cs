using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configure API key authorization
            IO.Swagger.Client.Configuration.Default.BasePath = "https://maze.hightechict.nl";
            IO.Swagger.Client.Configuration.Default.AddDefaultHeader("Authorization", "<your key here>");

            var playerApi = new IO.Swagger.Api.PlayerApi();
            await playerApi.ForgetAsync();
            Console.WriteLine("About to register...");
            await playerApi.RegisterAsync(name: "<your name here>");

            var mazesApi = new IO.Swagger.Api.MazesApi();
            Console.WriteLine("About to obtain all mazes...");
            var allMazes = await mazesApi.AllAsync();

            foreach (var maze in allMazes)
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

            var chosenMaze = allMazes[0];
            Console.WriteLine($"Choosing maze {chosenMaze.Name}");
            var enterResult = await mazesApi.EnterAsync(chosenMaze.Name);
            var mazeApi = new IO.Swagger.Api.MazeApi();
            var newPossibles = await mazeApi.MoveAsync(enterResult.PossibleMoveActions[0].Direction?.ToString());
            Console.WriteLine(string.Join(", ", newPossibles.PossibleMoveActions));

            Console.ReadLine();
        }
    }
}