namespace Occam.Console;

public interface IGameConsole
{
    ConsoleKeyInfo ReadKey();
}


public class GameConsole : IGameConsole
{
    public ConsoleKeyInfo ReadKey()
    {
        return System.Console.ReadKey(true);
    }
}