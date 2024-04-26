using Occam.Console.Views;

namespace Occam.Console;

public interface IGameLoop
{ 
    bool Run();
}
public class GameLoop : IGameLoop
{
    private const ConsoleKey QUITE_GAME = ConsoleKey.Escape;
    private readonly IPlayerInputService _playerInputService;
    private IView _view;
    private bool _firstRun = true;

    public GameLoop(IMainMenuView mainMenu, IPlayerInputService playerInputService)
    {
        _view = mainMenu;
        _playerInputService = playerInputService;
    }

    public bool Run()
    {
        TryInitialRendering();
        
        var input = _playerInputService.AwaitPlayer();
        
        if (input.Key == QUITE_GAME) return false;
        
        UpdateView(input);
        
        return true;
    }

    private void UpdateView(ConsoleKeyInfo response)
    {
        if (!_view.ReceivePlayerInput(response, out IView? newView)) return;
        
        _view = newView!;
        
        _view.Render();
    }

    private void TryInitialRendering()
    {
        if (!_firstRun) return;
        
        _view.Render();
        
        _firstRun = false;
    }
}