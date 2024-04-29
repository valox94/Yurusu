namespace Occam.Console;

public interface IGameConsole
{
    ConsoleKeyInfo ReadKey();
    void SetCursorPosition(int left, int top);
    void Write(char s);
}


public class GameConsole : IGameConsole
{
    public ConsoleKeyInfo ReadKey()
    {
        return System.Console.ReadKey(true);
    }

    public void SetCursorPosition(int left, int top)
    {
        System.Console.SetCursorPosition(left,top);
    }

    public void Write(char s)
    {
        System.Console.Write(s);
    }
}