namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public void SetToIntroState()
    {
        _state.TransitionToIntroState();
    }
}