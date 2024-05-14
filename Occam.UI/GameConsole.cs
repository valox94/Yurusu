namespace Occam.UI;

public interface IGameConsole
{
    void WriteLine(string message);
    void ReadKey();
}

public class GameConsole : IGameConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void ReadKey()
    {
        Console.ReadKey();
    }
}