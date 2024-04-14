using Occam.Application.Interface.View;
using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public async Task DisplayAsync(string[] text)
    {
        await InternalState.DisplayAsync(text);
    }
    
    public interface IIntroGameState : IGameState { }
    
    public partial class IntroGameState : GameState, IIntroGameState
    {
        private readonly IViewBox _storyViewBox;

        public IntroGameState(ITypingAudio typingAudio, IViewBox storyViewBox) : base(typingAudio)
        {
            _storyViewBox = storyViewBox;
        }

        public override async Task DisplayAsync(string[] message)
        {
            TypingAudio.StartTyping();
            var currentLine = 0;
            foreach (var line in message)
            {
                currentLine++;
                var words = line.Split(" ");
                
                foreach (var word in words)
                {
                    await Task.Delay(60);
                    _storyViewBox.Display(word + " ",TypingAudio);
                }
                if (currentLine < message.Length)
                {
                    await Task.Delay(100);
                    _storyViewBox.AddBreak(TypingAudio);
                }
            }
            TypingAudio.StopTyping();
        }
    }

    public partial class GameMenuState
    {
        public override async Task DisplayAsync(string[] message)
        {
            TypingAudio.StartTyping();
            var currentLine = 0;
            foreach (var line in message)
            {
                currentLine++;
                var words = line.Split(" ");
                
                foreach (var word in words)
                {
                    _menuViewBox.Display(word + " ",TypingAudio);
                }
                if (currentLine < message.Length)
                {
                    _menuViewBox.AddBreak(TypingAudio);
                }
            }
            
            TypingAudio.StopTyping();

        }
    }
}