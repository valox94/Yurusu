using Occam.Console.Views.Components;

namespace Occam.Console.Views;

public interface IMainMenuView : IView
{
}
public class MainMenuView : IMainMenuView
{
    private readonly IGameConsole _console;
    private readonly INarrativeViewComponent _narrativeViewComponent;

    public MainMenuView(IGameConsole console, INarrativeViewComponent narrativeViewComponent)
    {
        _console = console;
        _narrativeViewComponent = narrativeViewComponent;
    }

    public bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        _narrativeViewComponent.SetSize(25,10);
        _narrativeViewComponent.SetTitle("Narrative");
        _narrativeViewComponent.Render();
    }
}