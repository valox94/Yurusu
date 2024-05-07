namespace Occam.Console.Views.Components;

public interface IViewComponent : IView
{
    void SetSize(int width, int height);
    void SetTitle(string title);
    void SetContent(string content);
    void SetPosition(int x, int y);
}

public abstract class ViewComponent : IViewComponent
{
    private const int PADDING = 1;
    private readonly IGameConsole _console;
    private const char HORIZONTAL_BORDER_CHAR = '═';
    private const char VERTICAL_BORDER_CHAR = '║';
    private const char TOP_LEFT_CORNER_CHAR = '╔';
    private const char TOP_RIGHT_CORNER_CHAR = '╗';
    private const char BOTTOM_LEFT_CORNER_CHAR = '╚';
    private const char BOTTOM_RIGHT_CORNER_CHAR = '╝';
    private int _maxHeight = 0;
    private int _maxWidth = 0;
    private readonly IViewComponentTitle _title;
    private readonly IContentViewComponent _content;
    private int _xPosition;
    private int _yPosition;

    public ViewComponent(IGameConsole console, IViewComponentTitle title,
        IContentViewComponent content)
    {
        _console = console;
        _title = title;
        _content = content;
    }
    public bool ReceivePlayerInput(ConsoleKeyInfo keyInfo, out IView? view)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        RenderHorizontalBorder(0, TOP_LEFT_CORNER_CHAR, TOP_RIGHT_CORNER_CHAR);
        RenderSideBorders();
        RenderHorizontalBorder(_maxHeight - 1, BOTTOM_LEFT_CORNER_CHAR, BOTTOM_RIGHT_CORNER_CHAR);
        _title.Render();
        _content.Render();
    }
    
    private void RenderSideBorders()
    {
        if (_maxHeight > 2) // Ensure there's space for at least one vertical border between corners
        {
            for (int y = 1; y < _maxHeight - 1; y++)
            {
                _console.WriteAt(0+_xPosition, y +_yPosition, VERTICAL_BORDER_CHAR);
                if (_maxWidth > 1)
                {
                    _console.WriteAt(_maxWidth - 1 + _xPosition, y +_yPosition, VERTICAL_BORDER_CHAR);
                }
            }
        }
    }

    private void RenderHorizontalBorder(int y, char leftCorner, char rightCorner)
    {
        if (_maxWidth < 2) return; // Ensure there's room for at least two corners

        _console.WriteAt(0 + _xPosition, y + _yPosition, leftCorner);
        for (int x = 1; x < _maxWidth - 1; x++)
        {
            _console.WriteAt(x + _xPosition, y + _yPosition, HORIZONTAL_BORDER_CHAR);
        }
        _console.WriteAt(_maxWidth - 1 + _xPosition, y + _yPosition, rightCorner);
    }
    

    public void SetSize(int width, int height)
    {
        if (width < 1 || height < 1)
            throw new ArgumentException("Width and height must be at least 1.");

        _maxWidth = width;
        _maxHeight = height;
        
    }

    public void SetTitle(string title)
    {
        _title.SetValue(title);
        _title.SetPosition(_xPosition, _yPosition);
        _title.SetMaxLength(_maxWidth);
    }

    public void SetContent(string content)
    {
        _content.SetContent(content);
        _content.SetPosition(_xPosition+PADDING,_yPosition+PADDING);
        _content.SetSize(_maxWidth-PADDING-PADDING, _maxHeight-PADDING-PADDING);
    }

    public void SetPosition(int x, int y)
    {
        _xPosition = x;
        _yPosition = y;
    }
}