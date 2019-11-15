using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configure API key authorization
            IO.Swagger.Client.Configuration.Default.BasePath = "<<THE SERVER ADDRESS>>";
            IO.Swagger.Client.Configuration.Default.AddDefaultHeader("Authorization", "<<YOUR TOKEN>>");

            var playerApi = new IO.Swagger.Api.PlayerApi();
            Console.WriteLine("About to register...");
            await playerApi.RegisterAsync(name: "Amazing Player");

            var mazesApi = new IO.Swagger.Api.MazesApi();
            Console.WriteLine("About to obtain all mazes...");
            var allMazes = await mazesApi.AllAsync();

            foreach (var maze in allMazes)
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

            Console.ReadLine();
        }
    }
}