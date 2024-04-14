namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public void SetToMenuState()
    {
        _state.TransitionToIntroState();
    }
}