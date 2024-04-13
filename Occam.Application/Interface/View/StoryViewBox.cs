using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.View;


public class StoryViewBox : ViewBox
{
    private const int BOX_HEIGHT = 10;
    private const int BOX_WIDTH = 40;
    private const int BOX_PADDING = 1;
    private const char BOX_CHAR = '*';

    private int _leftContentColumn;
    private int _rightContentColumn;

    private int _topContentRow;
    private int _bottomContentRow;

    private int _originLeft;
    private int _originTop;
        
    private int _cursorLeft;
    private int _cursorTop;

    public StoryViewBox()
    {
        SetOrigin(0, 0);
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
        DrawBorders();
        Console.ResetColor();
    }

    private void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(_originLeft + left, _originTop + top);
    }

    private void DrawBorders()
    {
        SetCursorPosition(0, 0);
        Console.WriteLine(new string(BOX_CHAR, BOX_WIDTH));
        for (int height = 1; height < BOX_HEIGHT - 1; height++)
        {
            SetCursorPosition(0, height);
            Console.Write(BOX_CHAR);
            SetCursorPosition(BOX_WIDTH - 1, height);
            Console.Write(BOX_CHAR);
        }
        SetCursorPosition(0, BOX_HEIGHT - 1);
        Console.WriteLine(new string(BOX_CHAR, BOX_WIDTH));
    }

    public override void Display(string word, ITypingAudio typingAudio)
    {
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