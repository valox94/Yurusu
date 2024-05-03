namespace Occam.Console.Views.Components;

public interface IViewComponentTitle
{
    public void Render();
    public void SetValue(string title);
    void SetMaxLength(int length);
}

public class ViewComponentTitle : IViewComponentTitle
{
    private readonly IGameConsole _console;
    private string _title = string.Empty;
    private int _maxLength = 0;

    public ViewComponentTitle(IGameConsole console)
    {
        _console = console;
    }

    public void Render()
    {
        if(string.IsNullOrWhiteSpace(_title)) return;
    
        var titleLength = _title.Length;

        if (_maxLength <= 7) return;
        
        _console.WriteAt(1, 0,' ');
    
        for (int i = 2; i < titleLength + 2; i++)
        {
            if (i < _maxLength - 1)
            {
                if (i >= _maxLength - 1 && _title[i - 2] == ' ')
                {
                    break;
                }
                
                _console.WriteAt(i,0, _title[i - 2]);
            }
        }

        if (titleLength + 2 < _maxLength - 1)
        {
            _console.WriteAt(titleLength + 2, 0,' ');
        }
        else
        {
            _console.WriteAt(_maxLength-1,0,' ');
        }
    }
    
    public void SetValue(string title)
    {
        _title = title;
    }

    public void SetMaxLength(int maxLength)
    {
        _maxLength = maxLength;
    }
}