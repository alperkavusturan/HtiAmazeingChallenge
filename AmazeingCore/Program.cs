using System;
using System.Linq;
using System.Threading.Tasks;

namespace HightechICT
{
    class Program
    {
        static async Task Main(string[] args)
        {
			var httpClient = new System.Net.Http.HttpClient();
			httpClient.DefaultRequestHeaders.Add("Authorization", "HTI Thanks You [1527]");
			
			var client = new AmazeingClient("https://maze.hightechict.nl/", httpClient);

            await client.Forget();
            Console.WriteLine("About to register...");
            await client.Register(name: "<your name here>");
			
            var allMazes = await client.All();

            foreach (var maze in allMazes)
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

            var chosenMaze = allMazes.First();
            Console.WriteLine($"Choosing maze {chosenMaze.Name}");
            var enterResult = await client.Enter(chosenMaze.Name);
            Console.WriteLine(string.Join(", ", enterResult.PossibleMoveActions.Select( ma => ma.Direction)));
            Console.WriteLine($"Making a move");
            var newPossibles = await client.Move(enterResult.PossibleMoveActions.First().Direction);
            Console.WriteLine(string.Join(", ", newPossibles.PossibleMoveActions.Select( ma => ma.Direction)));

            Console.ReadLine();
        }
    }
}
