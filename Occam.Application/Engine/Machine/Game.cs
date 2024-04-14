using Occam.Application.Interface.Machine;
using Occam.Application.Interface;

namespace Occam.Application.Engine.Machine;

public interface IGameEngine
{
    Task RunAsync();
}

public partial class GameEngineMachine : IGameEngine
{
    public GameEngineMachine(IGameState state)
    {
        InternalState = state;
    }

    protected IGameState InternalState { get; set; }
}