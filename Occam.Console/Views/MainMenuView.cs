namespace Occam.Console.Views;

public interface IMainMenuView : IView
{
}
public class MainMenuView : IMainMenuView
{
    private readonly IGameConsole _console;

    public MainMenuView(IGameConsole console)
    {
        _console = console;
    }

    public bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        _console.SetCursorPosition(0, 0);
        _console.SetCursorPosition(1, 0);
        _console.SetCursorPosition(2, 0);
    }
}