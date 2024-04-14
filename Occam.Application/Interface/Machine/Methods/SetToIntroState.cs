namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public void SetToIntroState()
    {
        InternalState.TransitionToIntroState();
        InternalState.SetMachine(this);
    }
}