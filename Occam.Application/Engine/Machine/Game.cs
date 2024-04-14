using Occam.Application.Interface.Machine;
using Occam.Application.Interface;

namespace Occam.Application.Engine.Machine;

public interface IGameEngine
{
    Task RunAsync();
    void SetToMenuState();
    GameEngineMachine.IGameState InternalState { get; set; }
}

public partial class GameEngineMachine : IGameEngine
{
    public GameEngineMachine(IGameState state)
    {
        InternalState = state;
        InternalState.SetMachine(this);
    }

    public IGameState InternalState { get; set; }

    
}