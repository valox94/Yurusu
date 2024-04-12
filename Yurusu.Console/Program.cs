using Microsoft.Extensions.DependencyInjection;
using Yurusu.Application.Engine;
using Yurusu.Application.Interface.Machine;
using Yurusu.UI.Audio.Typing;

namespace Yurusu.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<IGameEngine, GameEngine>();
        
        services.AddGameInterfaceServices();
        
        var serviceProvider = services.BuildServiceProvider();

        IGameEngine engine = serviceProvider.GetRequiredService<IGameEngine>();
        
        engine.RunAsync().Wait();
    }
    
    public static void AddGameInterfaceServices(this IServiceCollection services)
    {
        services.AddSingleton<IGameInterface, GameInterfaceMachine>();
        services.AddSingleton<GameInterfaceMachine.IIntroGameState,GameInterfaceMachine.IntroGameState>();
        services.AddSingleton<GameInterfaceMachine.IGameState, GameInterfaceMachine.IntroGameState>();
        services.AddSingleton<ITypingAudio, TypingAudio>();
        services.AddSingleton<ITypingSound, TypingSound>();
    }
}