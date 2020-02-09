using AmazeingCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazeingCore.Helper
{
    public class MazeHelper
    {
        private AmazeingClient client { get; set; }
        public List<Tile> mazeMap { get; set; }
        public int CurrentScoreInHand { get; set; }
        public int CurrentScoreInBag { get; set; }
        public int DecideToExitSuccessRate { get; set; }
        public int RewardCollectionRate { get; set; }

        public MazeHelper(AmazeingClient _client, int _decideToExitSuccessRate, int _rewardCollectionRate)
        {
            client = _client;
            DecideToExitSuccessRate = _decideToExitSuccessRate;
            RewardCollectionRate = _rewardCollectionRate;
        }
        public async Task<bool> PlayMaze(MazeInfo maze, bool isInMaze, PossibleActionsAndCurrentScore possibleActions, Tile currentTile)
        {

            if (!isInMaze)
            {
                possibleActions = await client.EnterMaze(maze.Name);
                isInMaze = true;
                currentTile = new Tile();
                currentTile.isVisited = true;
                currentTile.Type = Enums.Tile.Start;
                mazeMap = new List<Tile>();
                mazeMap.Add(currentTile);
            }

            CurrentScoreInHand = possibleActions.CurrentScoreInHand;
            CurrentScoreInBag = possibleActions.CurrentScoreInBag;

            foreach (var action in possibleActions.PossibleMoveActions)
            {
                if (isExpansion(action, currentTile))
                {
                    var tile = SetNextCoordinate(action, currentTile);
                    tile = SetNextTileType(action, tile);
                    mazeMap.Add(tile);
                }
            }

            if (possibleActions.CanCollectScoreHere && DecideToCollectOrNot(maze, CurrentScoreInHand, CurrentScoreInBag))
            {
                var actions = await client.CollectScore();

                return await Move(maze, actions, currentTile);
            }

            if (possibleActions.CanExitMazeHere && DecideToExitOrNot(maze, possibleActions.CurrentScoreInBag))
            {
                await client.ExitMaze();
                return true;
            }

            return await Move(maze, possibleActions, currentTile);
        }

        public Task<bool> Move(MazeInfo maze, PossibleActionsAndCurrentScore possibleActions, Tile currentTile)
        {
            if (DecideToExitOrNot(maze, possibleActions.CurrentScoreInBag))
            {
                var listOfRoutes = new List<List<Enums.Direction>>();

                foreach (var item in mazeMap.Where(x => x.Type == Enums.Tile.Exit))
                {
                    var markedMap = new List<Tuple<Tile, int>>();
                    GetStepCountFromDestination(item, mazeMap, ref markedMap);
                    var route = GetShortestRoute(currentTile, markedMap);
                    listOfRoutes.Add(route);
                }

                var targetTile = listOfRoutes.OrderBy(x => x.Count).FirstOrDefault();
                var action = new MoveAction();

                switch (targetTile.FirstOrDefault().ToString())
                {
                    case "Up":
                        action.Direction = Direction.Up;
                        break;
                    case "Down":
                        action.Direction = Direction.Down;
                        break;
                    case "Right":
                        action.Direction = Direction.Right;
                        break;
                    case "Left":
                        action.Direction = Direction.Left;
                        break;
                }

                var actions = client.Move(action.Direction);

                currentTile = SetNextCoordinate(action, currentTile);
                currentTile = SetNextTileType(action, currentTile);

                mazeMap.Where(x => x.X == currentTile.X && x.Y == currentTile.Y).ToList().ForEach(s => s.isVisited = true);
                return PlayMaze(maze, true, actions.Result, currentTile);
            }
            else if (possibleActions.PossibleMoveActions.Where(p => !p.HasBeenVisited).Any())
            {
                var action = possibleActions.PossibleMoveActions.Where(p => !p.HasBeenVisited).OrderByDescending(s => s.RewardOnDestination).First();

                var actions = client.Move(action.Direction);

                currentTile = SetNextCoordinate(action, currentTile);
                currentTile = SetNextTileType(action, currentTile);
                currentTile.isVisited = true;

                mazeMap.Where(p => p.X == currentTile.X && p.Y == currentTile.Y).ToList().ForEach(p => p.isVisited = true);

                return PlayMaze(maze, true, actions.Result, currentTile);
            }
            else if (possibleActions.PossibleMoveActions.Where(p => p.AllowsScoreCollection).Any() && DecideToCollectOrNot(maze, possibleActions.CurrentScoreInHand, possibleActions.CurrentScoreInBag))
            {
                var action = possibleActions.PossibleMoveActions.Where(p => p.AllowsScoreCollection).First();

                var actions = client.Move(action.Direction);

                currentTile = SetNextCoordinate(action, currentTile);
                currentTile = SetNextTileType(action, currentTile);

                mazeMap.Where(p => p.X == currentTile.X && p.Y == currentTile.Y).ToList().ForEach(p => p.isVisited = true);

                return PlayMaze(maze, true, actions.Result, currentTile);
            }
            else if (possibleActions.PossibleMoveActions.Where(p => p.AllowsExit).Any() && DecideToExitOrNot(maze, possibleActions.CurrentScoreInBag))
            {
                var action = possibleActions.PossibleMoveActions.Where(p => p.AllowsExit).First();

                var actions = client.Move(action.Direction);

                currentTile = SetNextCoordinate(action, currentTile);
                currentTile = SetNextTileType(action, currentTile);

                mazeMap.Where(p => p.X == currentTile.X && p.Y == currentTile.Y).ToList().ForEach(p => p.isVisited = true);

                return PlayMaze(maze, true, actions.Result, currentTile);
            }
            else
            {
                var listOfRoutes = new List<List<Enums.Direction>>();

                foreach (var item in mazeMap.Where(x => !x.isVisited))
                {
                    var markedMap = new List<Tuple<Tile, int>>();
                    GetStepCountFromDestination(item, mazeMap, ref markedMap);
                    var route = GetShortestRoute(currentTile, markedMap);
                    listOfRoutes.Add(route);
                }

                var targetTile = listOfRoutes.OrderBy(x => x.Count).FirstOrDefault();

                if (targetTile == null || targetTile.Count == 0)
                {
                    foreach (var item in mazeMap.Where(x => x.Type == Enums.Tile.Exit))
                    {
                        var markedMap = new List<Tuple<Tile, int>>();
                        GetStepCountFromDestination(item, mazeMap, ref markedMap);
                        var route = GetShortestRoute(currentTile, markedMap);
                        listOfRoutes.Add(route);
                    }

                    targetTile = listOfRoutes.OrderBy(x => x.Count).FirstOrDefault();
                }

                if (targetTile != null && targetTile.Count > 0)
                {
                    var action = new MoveAction();

                    switch (targetTile.First().ToString())
                    {
                        case "Up":
                            action.Direction = Direction.Up;
                            break;
                        case "Down":
                            action.Direction = Direction.Down;
                            break;
                        case "Right":
                            action.Direction = Direction.Right;
                            break;
                        case "Left":
                            action.Direction = Direction.Left;
                            break;
                    }

                    var lastPossibleActions = client.Move(action.Direction);


                    currentTile = SetNextCoordinate(action, currentTile);
                    currentTile = SetNextTileType(action, currentTile);

                    mazeMap.Where(x => x.X == currentTile.X && x.Y == currentTile.Y).ToList().ForEach(s => s.isVisited = true);

                    return PlayMaze(maze, true, lastPossibleActions.Result, currentTile);
                }
                else
                {
                    // If i stuck, i will choose a random action 
                    Random random = new Random();
                    var randomNum = random.Next(possibleActions.PossibleMoveActions.Count);

                    var randomAction = possibleActions.PossibleMoveActions.ToList()[randomNum];
                    var randomPossibleActions = client.Move(randomAction.Direction);


                    currentTile = SetNextCoordinate(randomAction, currentTile);
                    currentTile = SetNextTileType(randomAction, currentTile);

                    mazeMap.Where(x => x.X == currentTile.X && x.Y == currentTile.Y).ToList().ForEach(s => s.isVisited = true);

                    return PlayMaze(maze, true, randomPossibleActions.Result, currentTile);
                }


            }
        }

        public bool isExpansion(MoveAction action, Tile currentTile)
        {
            if (!action.HasBeenVisited)
            {
                switch (action.Direction)
                {
                    case Direction.Up:
                        if (!mazeMap.Where(p => p.X == currentTile.X && p.Y == currentTile.Y + 1).Any())
                            return true;
                        break;
                    case Direction.Down:
                        if (!mazeMap.Where(p => p.X == currentTile.X && p.Y == currentTile.Y - 1).Any())
                            return true;
                        break;
                    case Direction.Right:
                        if (!mazeMap.Where(p => p.X == currentTile.X + 1 && p.Y == currentTile.Y).Any())
                            return true;
                        break;
                    case Direction.Left:
                        if (!mazeMap.Where(p => p.X == currentTile.X - 1 && p.Y == currentTile.Y).Any())
                            return true;
                        break;
                }
            }

            return false;
        }

        public Tile SetNextCoordinate(MoveAction action, Tile currentTile)
        {
            var returnTile = new Tile { X = currentTile.X, Y = currentTile.Y };

            switch (action.Direction)
            {
                case Direction.Up:
                    returnTile.Y++;
                    break;
                case Direction.Down:
                    returnTile.Y--;
                    break;
                case Direction.Right:
                    returnTile.X++;
                    break;
                case Direction.Left:
                    returnTile.X--;
                    break;
            }

            return returnTile;
        }

        public Tile SetNextTileType(MoveAction action, Tile newTile)
        {
            var returnTile = new Tile { X = newTile.X, Y = newTile.Y };

            if (action.AllowsExit)
            {
                returnTile.Type = Enums.Tile.Exit;
            }
            else if (action.AllowsScoreCollection)
            {
                returnTile.Type = Enums.Tile.Collection;
            }
            else if (action.IsStart)
            {
                returnTile.Type = Enums.Tile.Start;
            }
            else if (action.RewardOnDestination == 10 && !action.AllowsScoreCollection)
            {
                returnTile.Type = Enums.Tile.o;
            }
            else if (action.RewardOnDestination == 0 && !action.IsStart)
            {
                returnTile.Type = Enums.Tile.x;
            }

            return returnTile;
        }

        public bool DecideToCollectOrNot(MazeInfo maze, int currentInHand, int currentInBag)
        {
            var currentSuccess = currentInHand * 100 / (maze.PotentialReward - currentInBag);

            if (RewardCollectionRate <= currentSuccess)
            {
                return true;
            }

            return false;
        }

        public bool DecideToExitOrNot(MazeInfo maze, int currentInBag)
        {
            var currentSuccess = currentInBag * 100 / maze.PotentialReward;

            if (DecideToExitSuccessRate <= currentSuccess)
            {
                return true;
            }

            return false;
        }

        public static List<Enums.Direction> GetShortestRoute(Tile startPoint, List<Tuple<Tile, int>> markedMap)
        {
            var directionList = new List<Enums.Direction>();
            var tile = markedMap.Where(x => x.Item1.X == startPoint.X && x.Item1.Y == startPoint.Y).FirstOrDefault();

            while (tile != null && tile?.Item2 > 0)
            {
                // Try to find next step of my shortest route
                var nextTile = markedMap.Where(x => x.Item2 == tile.Item2 - 1 && (x.Item1.X == tile.Item1.X || x.Item1.Y == tile.Item1.Y) && (Math.Abs(x.Item1.X - tile.Item1.X) == 1 || Math.Abs(x.Item1.Y - tile.Item1.Y) == 1)).FirstOrDefault();

                if (nextTile.Item1.X == tile.Item1.X - 1 && nextTile.Item1.Y == tile.Item1.Y)
                {
                    directionList.Add(Enums.Direction.Left);
                }
                else if (nextTile.Item1.X == tile.Item1.X + 1 && nextTile.Item1.Y == tile.Item1.Y)
                {
                    directionList.Add(Enums.Direction.Right);
                }
                else if (nextTile.Item1.X == tile.Item1.X && nextTile.Item1.Y == tile.Item1.Y - 1)
                {
                    directionList.Add(Enums.Direction.Down);
                }
                else if (nextTile.Item1.X == tile.Item1.X && nextTile.Item1.Y == tile.Item1.Y + 1)
                {
                    directionList.Add(Enums.Direction.Up);
                }

                tile = nextTile;
            }

            return directionList;
        }

        public void GetStepCountFromDestination(Tile destinationTile, List<Tile> mazeMap, ref List<Tuple<Tile, int>> markedMap)
        {
            var stepsMap = new List<Tuple<Tile, int>>();
            var countedTileList = new List<Tuple<Tile, int>>();
            markedMap.Add(Tuple.Create(destinationTile, 0));

            while (mazeMap.Count > markedMap.Count)
            {
                var tempMap = new List<Tuple<Tile, int>>();

                foreach (var item in markedMap)
                {
                    if (!stepsMap.Where(p => p.Item1.X == item.Item1.X && p.Item1.Y == item.Item1.Y).Any())
                    {
                        var nextTiles = mazeMap.Where(p => (p.X == item.Item1.X + 1 && p.Y == item.Item1.Y) || (p.X == item.Item1.X - 1 && p.Y == item.Item1.Y) || (p.X == item.Item1.X && p.Y == item.Item1.Y + 1) || (p.X == item.Item1.X && p.Y == item.Item1.Y - 1)).ToList();

                        foreach (var tile in nextTiles)
                        {
                            if (!countedTileList.Where(p => p.Item1.X == tile.X && p.Item1.Y == tile.Y).Any())
                            {
                                if (stepsMap.Where(p => p.Item1.X == tile.X && p.Item1.Y == tile.Y).Any())
                                    continue;

                                tempMap.Add(Tuple.Create(tile, item.Item2 + 1));
                                countedTileList.Add(Tuple.Create(tile, item.Item2 + 1));
                            }

                        }

                        stepsMap.Add(item);
                    }

                }

                markedMap.AddRange(tempMap);
            }
        }

    }
}
