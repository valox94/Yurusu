using Yurusu.UI.Audio.Typing;

namespace Yurusu.Application.Interface.Machine;

public interface IGameInterface
{
    Task DisplayAsync(string[] introText);
    void SetToIntroState();
    GameInterfaceMachine.IGameState InternalState { get; set; } 
}

public partial class GameInterfaceMachine : IGameInterface
{
    private readonly IGameState _state;

    public GameInterfaceMachine(IGameState state)
    {
        _state = state;
        _state.SetMachine(this);
    }


    public IGameState InternalState { get; set; }
}