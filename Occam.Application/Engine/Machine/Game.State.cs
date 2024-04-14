using Occam.Application.Interface.Machine;

namespace Occam.Application.Engine.Machine;

public partial class GameEngineMachine : IGameEngine
{
    public interface IGameState
    {
        Task RunAsync();
    }

    public abstract class GameState : IGameState
    {
        public abstract Task RunAsync();
    }
}