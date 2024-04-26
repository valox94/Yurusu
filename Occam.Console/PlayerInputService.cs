namespace Occam.Console;

public interface IPlayerInputService
{
    ConsoleKeyInfo AwaitPlayer();
}


public class PlayerInputService : IPlayerInputService
{
    private readonly IGameConsole _gameConsole;

    public PlayerInputService(IGameConsole gameConsole)
    {
        _gameConsole = gameConsole;
    }

    public ConsoleKeyInfo AwaitPlayer()
    {
        return _gameConsole.ReadKey();
    }
}