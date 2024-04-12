using Yurusu.UI.Audio.Typing;

namespace Yurusu.Application.Interface.Machine;

public partial class GameInterfaceMachine : IGameInterface
{
    public async Task DisplayAsync(string[] message)
    {
        await _state.DisplayAsync(message);
    }
    
    public interface IIntroGameState : IGameState { }
    
    public class IntroGameState : GameState, IIntroGameState
    {
        public IntroGameState(ITypingAudio typingAudio) : base(typingAudio)
        {
        }

        public override async Task DisplayAsync(string[] message)
        {
            TypingAudio.StartTyping();
            await Task.Delay(1000);
            foreach (var line in message)
            {
                var words = line.Split(" ");
            
                foreach (var word in words)
                {
                    foreach (char character in word)
                    {
                        Console.Write(character);
                        await Task.Delay(20);
                    }
                    Console.Write(" ");
                    await Task.Delay(100);
                }
                Console.WriteLine();
            }
            TypingAudio.StopTyping();
            Console.WriteLine();
        }
    }
}