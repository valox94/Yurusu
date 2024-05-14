namespace Occam.UI;

public interface IPlayerInterface
{
    Task ShowMessageAsync(string message);
    Task WaitForPlayerAcknowledgementAsync();
}

public class PlayerInterface : IPlayerInterface
{
    private readonly IGameConsole _console;

    public PlayerInterface(IGameConsole console)
    {
        _console = console;
    }

    public Task ShowMessageAsync(string message)
    {
        _console.WriteLine(message);
        return Task.CompletedTask;
    }

    public Task WaitForPlayerAcknowledgementAsync()
    {
        _console.ReadKey();
        return Task.CompletedTask;
    }
}