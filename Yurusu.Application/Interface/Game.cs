using Yurusu.UI.Audio.Typing;

namespace Yurusu.Application.Interface;

public interface IGameInterface
{
    Task DisplayAsync(string[] introText);
}
public class GameInterface : IGameInterface
{
    private readonly ITypingAudio _typingAudio;

    public GameInterface(ITypingAudio typingAudio)
    {
        _typingAudio = typingAudio;
    }
    
    public async Task DisplayAsync(string[] message)
    {
        _typingAudio.StartTyping();
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
        _typingAudio.StopTyping();
        Console.WriteLine();
    }
}