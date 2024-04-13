using Occam.Application.Interface.Machine;
using Occam.Application.Interface;

namespace Occam.Application.Engine;

public interface IGameEngine
{
    Task RunAsync();
}

public class GameEngine : IGameEngine
{
    private readonly IGameInterface _interface;

    private readonly string[] _introText = new string[]
    {
        "Hello adventurer! Welcome to the Yurusu...",
        "",
        "",
        "Yurusu is a text-based adventure game where you will be able to explore the world of Yurusu.",
        "You will be able to interact with the world and its inhabitants, and make choices that will affect the outcome of your adventure.",
        "",
        "",
        "Press any key to start your adventure..."
    };

    public GameEngine(IGameInterface @interface)
    {
        _interface = @interface;
    }

    public async Task RunAsync()
    {
        _interface.SetToIntroState();
        _interface.Initialize();
        await _interface.DisplayAsync(_introText);
        Console.ReadKey(true);
    }
    
    
}