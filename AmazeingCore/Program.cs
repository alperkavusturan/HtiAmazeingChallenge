using AmazeingCore.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmazeingCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "HTI Thanks You [1527]");
            var client = new AmazeingClient("https://maze.hightechict.nl/", httpClient);

            Console.WriteLine("******************  Register Player  *****************");
            await client.ForgetPlayer();
            Console.WriteLine("About to register...");
            var registerResponse = client.RegisterPlayer(name: "Amazing Player");


            Console.WriteLine("About to obtain all mazes...");
            var allMazes = await client.AllMazes();

            do
            {
                Console.WriteLine("******************  Available mazes  ******************");

                foreach (var maze in allMazes)
                    Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

                Console.WriteLine("******************    Maze Options    *****************");

                PickMaze:
                Console.WriteLine("Enter maze name which you wanna play...");
                var mazeName = Console.ReadLine();
                var pickMaze = allMazes.Where(x => x.Name == mazeName).FirstOrDefault();

                Console.WriteLine("Enter a value for decide to exit rate");
                var decideToExitRate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a value for reward collect rate");
                var rewardCollectRate = Convert.ToInt32(Console.ReadLine());

                var mazeHelper = new MazeHelper(client, decideToExitRate, rewardCollectRate);

                if (pickMaze == null)
                {
                    Console.WriteLine("You should type name right!");
                    goto PickMaze;
                }

                try
                {
                    var isInMaze = false;
                    await mazeHelper.PlayMaze(pickMaze, isInMaze, new PossibleActionsAndCurrentScore(), new Entity.Tile());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("******************  Exception Message  ****************");
                    Console.WriteLine(ex.ToString());
                }

                allMazes.Remove(pickMaze);

                Console.WriteLine("******************Deal Or Not Deal*****************");               
                Console.WriteLine("You just exit from the maze! Type q if you wanna quit from game.");
            }
            while (Console.ReadKey().KeyChar != 'q');

            Console.WriteLine("Thanks..");

            Console.ReadLine();
        }
    }
}
