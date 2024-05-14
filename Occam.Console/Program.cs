using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Occam.Application;

namespace Occam.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        
        var appAssembly = typeof(AppSettings).Assembly;
        var consoleAssembly = typeof(ConsoleSettings).Assembly;

        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(appAssembly));
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(consoleAssembly));
        
        // services.AddSingleton<IGameEngine, GameEngine>();

        var serviceProvider = services.BuildServiceProvider();
        
        var mediatR = serviceProvider.GetRequiredService<IMediator>();

        mediatR.Send(new RunApplication.Request()).GetAwaiter().GetResult();

    }
    
}

