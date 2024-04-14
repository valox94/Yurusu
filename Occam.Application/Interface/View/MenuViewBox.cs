using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.View;

public class MenuViewBox : ViewBox
{
    private const int BOX_HEIGHT = 30;
    private const int BOX_WIDTH = 30;
    private const int BOX_PADDING = 1;
    private const string HEADER = "~ Main Menue ~";
    private int _leftContentColumn;
    private int _rightContentColumn;

    private int _topContentRow;
    private int _bottomContentRow;

    private int _originLeft;
    private int _originTop;
        
    private int _cursorLeft;
    private int _cursorTop;

    private const char HORIZONTAL_BORDER_CHAR = '═';
    private const char VERTICAL_BORDER_CHAR = '║';
    private const char TOP_LEFT_CORNER_CHAR = '╔';
    private const char TOP_RIGHT_CORNER_CHAR = '╗';
    private const char BOTTOM_LEFT_CORNER_CHAR = '╚';
    private const char BOTTOM_RIGHT_CORNER_CHAR = '╝';

    public MenuViewBox()
    {
        SetOrigin(0, 0);
    }
    
    public override void Dispose()
    {
        for (int top = _originLeft; top < _originTop; top++)
        {
            Console.SetCursorPosition(_originLeft, _originTop + top);
            Console.Write(new string(' ', BOX_WIDTH));
        }
    }
    
    public override void SetOrigin(int left, int top)
    {
        _originLeft = left;
        _originTop = top;

        _leftContentColumn = BOX_PADDING;
        _rightContentColumn = BOX_WIDTH - BOX_PADDING - 1;

        _topContentRow = BOX_PADDING;
        _bottomContentRow = BOX_HEIGHT - BOX_PADDING - 1;

        _cursorLeft = _leftContentColumn + 1; // Starting position within the content area
        _cursorTop = _topContentRow + 1;
    }

    public override void Initialize()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        SetCursorPosition(0, 0);
        DrawBorders();
        Console.ResetColor();
    }

    private void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(_originLeft + left, _originTop + top);
    }

    private void DrawBorders()
    {
        // Create the top border with the header
        string topBorder = TOP_LEFT_CORNER_CHAR + new string(HORIZONTAL_BORDER_CHAR, 3) + HEADER +
                           new string(HORIZONTAL_BORDER_CHAR, BOX_WIDTH - HEADER.Length - 5) + TOP_RIGHT_CORNER_CHAR;
    
        SetCursorPosition(0, 0);
        Console.WriteLine(topBorder);

        // Draw the sides
        for (int height = 1; height < BOX_HEIGHT - 1; height++)
        {
            SetCursorPosition(0, height);
            Console.Write(VERTICAL_BORDER_CHAR);
            SetCursorPosition(BOX_WIDTH - 1, height);
            Console.Write(VERTICAL_BORDER_CHAR);
        }

        // Create and write the bottom border
        string bottomBorder = BOTTOM_LEFT_CORNER_CHAR + new string(HORIZONTAL_BORDER_CHAR, BOX_WIDTH - 2) + BOTTOM_RIGHT_CORNER_CHAR;
        SetCursorPosition(0, BOX_HEIGHT - 1);
        Console.WriteLine(bottomBorder);
    }


    public override void Display(string word, ITypingAudio typingAudio)
    {
        if(_cursorTop == _topContentRow && _cursorLeft == _leftContentColumn && string.IsNullOrWhiteSpace(word))
        {
            return;
        }
        if(_cursorLeft + word.Length > _rightContentColumn)
        {
            if(_cursorTop + 1 >= _bottomContentRow)
            {
                PauseForUserToRead(typingAudio);
            }
            else
            {
                _cursorTop++;
                _cursorLeft = _leftContentColumn;
            }
        }
        Console.SetCursorPosition(_cursorLeft, _cursorTop);
        Console.Write(word);
        _cursorLeft = _cursorLeft + word.Length;
    }

    private void PauseForUserToRead(ITypingAudio typingAudio)
    {
        typingAudio.StopTyping();
        Console.ReadKey(true);
        typingAudio.StartTyping();
        Reset();
    }

    public override void AddBreak(ITypingAudio typingAudio)
    {
        if(_cursorTop == _topContentRow && _cursorLeft == _leftContentColumn)
        {
            return;
        }
        if(_cursorTop + 1 >= _bottomContentRow)
        {
            PauseForUserToRead(typingAudio);
        }
        else
        {
            _cursorTop++;
            _cursorLeft = _leftContentColumn;
        }
    }

    public override void Reset()
    {
        ClearContentArea();
        SetCursorToContentOrigin();
    }
    
    private void SetCursorToContentOrigin()
    {
        _cursorLeft = _leftContentColumn;
        _cursorTop = _topContentRow;
    }

    private void ClearContentArea()
    {
        for (int top = _topContentRow; top < _bottomContentRow; top++)
        {
            Console.SetCursorPosition(_originLeft + BOX_PADDING, _originTop + top);
            Console.Write(new string(' ', BOX_WIDTH - (BOX_PADDING * 2)));
        }
    }
    
}