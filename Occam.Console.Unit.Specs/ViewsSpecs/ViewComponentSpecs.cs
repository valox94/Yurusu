using FakeItEasy;
using Occam.Console.Views;
using Xunit;

namespace Occam.Console.Unit.Specs.ViewsSpecs;

public class ViewComponentSpecs
{
    public class WhenComponentSizeIsThreeByFive
    {
        [Fact]
        public void should_show_left_corner_border_char_at_origin()
        {
            var console = A.Fake<IGameConsole>();
            
            var viewComponent = new ViewComponent(console);
            
            viewComponent.SetSize(3, 5);
            
            viewComponent.Render();
            
            A.CallTo(() => console.SetCursorPosition(0, 0)).MustHaveHappened();
            A.CallTo(() => console.Write('╔')).MustHaveHappened();
        }
        [Fact]
        public void should_show_horizontal_border_across_the_top_but_not_at_either_end()
        {
            var console = A.Fake<IGameConsole>();
            
            var viewComponent = new ViewComponent(console);
            
            viewComponent.SetSize(3, 5);
            
            viewComponent.Render();
            
            A.CallTo(() => console.SetCursorPosition(1, 0)).MustHaveHappened();
            A.CallTo(() => console.Write('═')).MustHaveHappened();
        }
        [Fact]
        public void should_show_right_corner_border_at_the_far_right_top_side()
        {
            var console = A.Fake<IGameConsole>();
            
            var viewComponent = new ViewComponent(console);
            
            viewComponent.SetSize(3, 5);
            
            viewComponent.Render();
            
            A.CallTo(() => console.SetCursorPosition(2, 0)).MustHaveHappened();
            A.CallTo(() => console.Write('╗')).MustHaveHappened();
        }
        [Fact]
        public void should_show_verticle_border_on_either_side_except_for_corners()
        {
            var console = A.Fake<IGameConsole>();
            
            var viewComponent = new ViewComponent(console);
            
            viewComponent.SetSize(3, 5);
            
            viewComponent.Render();
            
            A.CallTo(() => console.SetCursorPosition(0, 1)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
            A.CallTo(() => console.SetCursorPosition(0, 2)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
            A.CallTo(() => console.SetCursorPosition(0, 3)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
            
            A.CallTo(() => console.SetCursorPosition(2, 1)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
            A.CallTo(() => console.SetCursorPosition(2, 2)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
            A.CallTo(() => console.SetCursorPosition(2, 3)).MustHaveHappened();
            A.CallTo(() => console.Write('║')).MustHaveHappened();
        }
        [Fact]
        public void should_show_left_corner_border_char_at_bottom_left()
        {
            var console = A.Fake<IGameConsole>();

            var viewComponent = new ViewComponent(console);

            viewComponent.SetSize(3, 5);

            viewComponent.Render();

            A.CallTo(() => console.SetCursorPosition(0, 4)).MustHaveHappened(); // Bottom row is at index 4 when height is 5
            A.CallTo(() => console.Write('╚')).MustHaveHappened(); // Bottom left corner character
        }

        [Fact]
        public void should_show_horizontal_border_across_the_bottom_but_not_at_either_end()
        {
            var console = A.Fake<IGameConsole>();

            var viewComponent = new ViewComponent(console);

            viewComponent.SetSize(3, 5);

            viewComponent.Render();

            A.CallTo(() => console.SetCursorPosition(1, 4)).MustHaveHappened(); // Middle of the bottom border
            A.CallTo(() => console.Write('═')).MustHaveHappened(); // Horizontal border character
        }

        [Fact]
        public void should_show_right_corner_border_at_the_far_right_bottom_side()
        {
            var console = A.Fake<IGameConsole>();

            var viewComponent = new ViewComponent(console);

            viewComponent.SetSize(3, 5);

            viewComponent.Render();

            A.CallTo(() => console.SetCursorPosition(2, 4)).MustHaveHappened(); // Bottom row right corner when width is 3
            A.CallTo(() => console.Write('╝')).MustHaveHappened(); // Bottom right corner character
        }
    }

}