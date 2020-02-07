using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HightechICT
{
    public interface IAmazeingClient
    {
        string BaseUrl { get; set; }
        bool ReadResponseAsString { get; set; }

        Task<ICollection<MazeInfo>> All();
        Task<ICollection<MazeInfo>> All(CancellationToken cancellationToken);
        Task<PossibleActionsAndCurrentScore> CollectScore();
        Task<PossibleActionsAndCurrentScore> CollectScore(CancellationToken cancellationToken);
        Task<PossibleActionsAndCurrentScore> Enter(string mazeName);
        Task<PossibleActionsAndCurrentScore> Enter(string mazeName, CancellationToken cancellationToken);
        Task ExitMaze();
        Task ExitMaze(CancellationToken cancellationToken);
        Task Forget();
        Task Forget(CancellationToken cancellationToken);
        Task<PlayerInfo> Get();
        Task<PlayerInfo> Get(CancellationToken cancellationToken);
        Task<PossibleActionsAndCurrentScore> Move(Direction direction);
        Task<PossibleActionsAndCurrentScore> Move(Direction direction, CancellationToken cancellationToken);
        Task<PossibleActionsAndCurrentScore> PossibleActions();
        Task<PossibleActionsAndCurrentScore> PossibleActions(CancellationToken cancellationToken);
        Task Register(string name);
        Task Register(string name, CancellationToken cancellationToken);
    }
}