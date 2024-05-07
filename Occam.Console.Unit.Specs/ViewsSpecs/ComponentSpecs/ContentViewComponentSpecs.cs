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
                    A<int>.Ignored,
                    A<int>.That.IsGreaterThan(13), 
                    A<char>.Ignored))
                .MustNotHaveHappened();
        }
        [Theory]
        [InlineData("short loooong","loooong",8, 5)]
        [InlineData("This is a narrative view component.","view component.",23,8)]
        public void Should_not_write_partial_words_when_size_allows_the_word_on_one_line(
            string content, string secondLine, int width, int height)
        {
            var console = A.Fake<IGameConsole>();
            var contentComponent = new ContentViewComponent(console);
            
            contentComponent.SetContent(content);
            contentComponent.SetPosition(0, 0);
            contentComponent.SetSize(width, height);
            
            var calls = new StringBuilder();
            A.CallTo(() => console.WriteAt(A<int>.Ignored,1, A<char>.Ignored))
                .Invokes((int x, int y, char c) =>
                {
                    calls.Append(c);
                });
            
            contentComponent.Render();
            
            Assert.Equal(secondLine, calls.ToString());
        }
    }
    public class ReceivePlayerInputSpecs
    {
        
    }
}

