using Microsoft.Extensions.DependencyInjection;
using Occam.Application.Engine.Machine;
using Occam.Application.Interface.Machine;
using Occam.Application.Interface.View;
using Occam.UI.Audio.Typing;

namespace Occam.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<IGameEngine, GameEngineMachine>();
        
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
        services.AddSingleton<GameEngineMachine.IGameState, GameEngineMachine.IntroGameState>();

        services.AddSingleton<IViewBox, StoryViewBox>();
        services.AddSingleton<ITypingAudio, TypingAudio>();
        services.AddSingleton<ITypingSound, TypingSound>();
    }
}