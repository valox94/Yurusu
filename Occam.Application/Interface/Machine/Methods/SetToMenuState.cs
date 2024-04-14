using Occam.Application.Interface.View;
using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public void SetToMenuState()
    {
        InternalState.TransitionToMenuState();
    }

    public partial class IntroGameState
    {
        public void TransitionToMenuState()
        {
            _storyViewBox.Dispose();
            var menuBox = new MenuViewBox();
            Machine.InternalState = new GameMenuState(TypingAudio, menuBox);
            menuBox.Initialize();
            
        }
        public override void Initialize()
        {
            Console.CursorVisible = false;
            _storyViewBox.Initialize();
        }
    }
    
    public partial class GameMenuState : GameState
    {
        private readonly MenuViewBox _menuViewBox;

        public GameMenuState(ITypingAudio typingAudio, MenuViewBox menuViewBox) : base(typingAudio)
        {
            _menuViewBox = menuViewBox;
        }

        public override void Initialize()
        {
            Console.CursorVisible = false;
        }
    }
}



