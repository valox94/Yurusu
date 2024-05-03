using System.Text;
using FakeItEasy;
using Occam.Console.Views;
using Occam.Console.Views.Components;
using Xunit;

namespace Occam.Console.Unit.Specs.ViewsSpecs.ComponentSpecs;

public class ContentViewComponentSpecs
{
    public class RenderSpecs
    {
        [Fact]
        public void Should_not_write_content_to_the_right_of_the_contents_position()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent("Test Content Test Content Test Content Test Content Test Content");
            contentComponent.SetPosition(5, 10);
            contentComponent.Render();
            
            A.CallTo(() => console.WriteAt(
                    A<int>.That.Not.IsGreaterThan(4), 
                    A<int>.Ignored,
                    A<char>.Ignored))
                .MustNotHaveHappened();
        }
        [Fact]
        public void Should_not_write_content_above_the_contents_position()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent("Test Content Test Content Test Content Test Content Test Content");
            contentComponent.SetPosition(5, 10);
            contentComponent.Render();
            
            A.CallTo(() => console.WriteAt(
                    A<int>.Ignored,
                    A<int>.That.Not.IsGreaterThan(9), 
                    A<char>.Ignored))
                .MustNotHaveHappened();
        }

        [Fact]
        public void Should_write_all_content_at_unique_positions()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            contentComponent.SetContent("Test Content Test Content Test Content Test Content Test Content");
            contentComponent.SetPosition(5, 10);
            contentComponent.SetSize(10, 20);
            
            var calls = new List<(int X,int Y)>();
            A.CallTo(() => console.WriteAt(A<int>.Ignored, A<int>.Ignored, A<char>.Ignored))
                .Invokes((int x, int y, char c) => calls.Add((x, y)));
            
            contentComponent.Render();
            
            Assert.Equal(calls.Count, calls.Distinct().Count());
        }
        [Fact]
        public void Should_not_write_content_beyond_right_edge_When_it_goes_beyond_the_size()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent("Test Content Test Content Test Content Test Content Test Content");
            contentComponent.SetPosition(5, 10);
            contentComponent.SetSize(10, 20);
            contentComponent.Render();
            
            A.CallTo(() => console.WriteAt(
                    A<int>.Ignored,
                    A<int>.That.IsGreaterThan(20), 
                    A<char>.Ignored))
                .MustNotHaveHappened();
        }
        [Fact]
        public void Should_write_all_characters_When_size_allows()
        {
            var content = "Test Content Test Content Test Content Test Content Test Content";
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            contentComponent.SetContent(content);
            contentComponent.SetPosition(5, 10);
            contentComponent.SetSize(10, 20);
            
            var calls = new StringBuilder();
            A.CallTo(() => console.WriteAt(A<int>.Ignored, A<int>.Ignored, A<char>.Ignored))
                .Invokes((int x, int y, char c) => calls.Append(c));
            
            contentComponent.Render();
            
            Assert.Equal(content.Replace(" ",""),calls.ToString());
        }
        [Fact]
        public void Should_not_write_content_beyond_bottom_edge_When_it_goes_beyond_the_size()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent("Test Content Test Content Test Content Test Content Test Content");
            contentComponent.SetPosition(5, 10);
            contentComponent.SetSize(5, 3);
            contentComponent.Render();
            
            A.CallTo(() => console.WriteAt(
                    A<int>.That.IsGreaterThan(7), 
                    A<int>.Ignored,
                    A<char>.Ignored))
                .MustNotHaveHappened();
        }
        [Fact]
        public void Should_not_write_partial_words_when_size_allows_the_word_on_one_line()
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent("short loooong");
            contentComponent.SetPosition(0, 0);
            contentComponent.SetSize(8, 5);
            
            var calls = new StringBuilder();
            A.CallTo(() => console.WriteAt(1,A<int>.Ignored, A<char>.Ignored))
                .Invokes((int x, int y, char c) =>
                {
                    calls.Append(c);
                });
            
            contentComponent.Render();
            
            Assert.Equal("loooong", calls.ToString());
        }
    }
    public class ReceivePlayerInputSpecs
    {
        
    }
}


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
                    
                    if(currentWord.Length > remainingArea
                       && currentWord.Length <= _width) break;
                }

                if(ii == 0 && _content[contentCursor] == ' ')
                {
                    contentCursor++;
                    continue;
                }
                
                _console.WriteAt(_positionX + i, _positionY + ii, _content[contentCursor]);
            
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
