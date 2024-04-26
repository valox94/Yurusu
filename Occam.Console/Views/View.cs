namespace Occam.Console.Views;

public interface IView
{
    bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view);
    void Render();
}
