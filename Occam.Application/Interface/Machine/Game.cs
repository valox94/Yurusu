using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.Machine;

public interface IGameInterface
{
    Task DisplayAsync(string[] text);
    void SetToIntroState();
    GameInterfaceMachine.IGameState InternalState { get; set; }
    void Initialize();
    void SetToMenuState();

}

public partial class GameInterfaceMachine : IGameInterface
{

    public GameInterfaceMachine(IGameState state)
    {
        InternalState = state;
        InternalState.SetMachine(this);
    }
    
    public IGameState InternalState { get; set; }
    
    public void Initialize()
    {
        InternalState.Initialize();
    }
}