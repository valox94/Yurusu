using Occam.Application.Interface.View;
using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public async Task DisplayAsync(string[] message)
    {
        await _state.DisplayAsync(message);
    }
    
    public interface IIntroGameState : IGameState { }
    
    public class IntroGameState : GameState, IIntroGameState
    {
        private readonly IViewBox _StoryViewBox;

        public IntroGameState(ITypingAudio typingAudio, IViewBox storyViewBox) : base(typingAudio)
        {
            _StoryViewBox = storyViewBox;
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
                    _StoryViewBox.Display(word + " ",TypingAudio);
                }
                if (currentLine < message.Length)
                {
                    await Task.Delay(100);
                    _StoryViewBox.AddBreak(TypingAudio);
                }
            }
            TypingAudio.StopTyping();
        }

        public override void Initialize()
        {
            Console.CursorVisible = false;
            _StoryViewBox.Initialize();
        }
    }
}