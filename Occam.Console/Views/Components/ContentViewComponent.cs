namespace Occam.Console.Views.Components;


public interface IContentViewComponent : IView
{
    void SetSize(int width, int height);
    void SetContent(string content);
    void SetPosition(int x, int y);
}


public class ContentViewComponent : IContentViewComponent
{
    private readonly IGameConsole _console;
    private int _positionX;
    private int _positionY;
    private string _content;
    private int _height;
    private int _width;

    public ContentViewComponent(IGameConsole console)
    {
        _console = console;
    }

    public bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        var contentCursor = 0;

        for (int i = 0; i < _height; i++)
        {
            for (int ii = 0; ii < _width; ii++)
            {
                if (contentCursor >= _content.Length) return;

                if(_content[contentCursor] == ' ')
                {
                    var remainingArea = _width - ii;
                    var remainingContent = _content.Substring(contentCursor);
                    var words = remainingContent.Split(" ");
                    var currentWord = words.FirstOrDefault(x => !string.IsNullOrEmpty(x));
                    
                    if (currentWord is null) return;
                    
                    currentWord = " " + currentWord;

                    if (currentWord.Length > remainingArea
                        && currentWord.Length <= _width)
                    {
                        contentCursor++;
                        break;
                    };
                }

                if(ii == 0 && _content[contentCursor] == ' ')
                {
                    contentCursor++;
                    continue;
                }
                
                _console.WriteAt(_positionX + ii, _positionY + i, _content[contentCursor]);
            
                contentCursor++;
            }
        }
    }

    public void SetSize(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void SetContent(string content)
    {
        _content = content;
    }

    public void SetPosition(int x, int y)
    {
        _positionX = x;
        _positionY = y;
    }
}
