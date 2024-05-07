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
        _narrativeViewComponent.SetPosition(10,5);
        _narrativeViewComponent.SetTitle("Narrative");
        _narrativeViewComponent.SetContent("The Bird of Hermes is my name, eating my wings to make me tame. " +
                                           "I will drink the blood of the sun, and the moon, and the stars. " +
                                           "I will swallow the world and all that is in it. " +
                                           "I will devour the universe and all that is beyond it. " +
                                           "I will consume all that is, and all that is not. " +
                                           "I will be the end of all things. ");
        _narrativeViewComponent.Render();
    }
}