using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.Machine;

public interface IGameInterface
{
    Task DisplayAsync(string[] introText);
    void SetToIntroState();
    GameInterfaceMachine.IGameState InternalState { get; set; }
    void Initialize();
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
    public void Initialize()
    {
        _state.Initialize();
    }
}