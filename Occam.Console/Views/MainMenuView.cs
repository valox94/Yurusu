namespace Occam.Console.Views;

public interface IMainMenuView : IView
{
}
public class MainMenuView : IMainMenuView
{
    public bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        throw new NotImplementedException();
    }
}