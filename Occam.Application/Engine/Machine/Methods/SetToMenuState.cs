using Occam.Application.Interface.Machine;

namespace Occam.Application.Engine.Machine;

public partial class GameEngineMachine
{
    public void SetToMenuState()
    {
        InternalState.TransitionToMenuState();
    }
    
    public partial class IntroGameState : Machine.GameEngineMachine.IGameState 
    {
        public override async void TransitionToMenuState()
        {
            var menuState = new GameMenuState(_interface);
            Machine.InternalState = menuState;
            menuState.RunAsync();

        }
    }
    
    public partial class GameMenuState : GameState
    {
        private readonly IGameInterface _interface;

        public GameMenuState(IGameInterface @interface)
        {
            _interface = @interface;
        }
    }
}

