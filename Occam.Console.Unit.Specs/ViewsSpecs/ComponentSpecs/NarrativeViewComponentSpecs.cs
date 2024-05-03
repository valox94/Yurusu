using FakeItEasy;
using Occam.Console.Views.Components;
using Xunit;

namespace Occam.Console.Unit.Specs.ViewsSpecs.ComponentSpecs;

//TODO: should write specs to utilize content view component when rendering narrative view component
public class NarrativeViewComponentSpecs
{
    public class RenderSpecs
    {
        public class WhenComponentSizeIsThreeByFive
        {
            [Fact]
            public void should_show_left_corner_border_char_at_origin()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();
                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);
                
                viewComponent.SetSize(3, 5);
                
                viewComponent.Render();
                
                A.CallTo(() => console.WriteAt(0, 0,'╔')).MustHaveHappened();
            }
            [Fact]
            public void should_show_horizontal_border_across_the_top_but_not_at_either_end()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);
                
                viewComponent.SetSize(3, 5);
                
                viewComponent.Render();
                
                A.CallTo(() => console.WriteAt(1, 0,'═')).MustHaveHappened();
            }
            [Fact]
            public void should_show_right_corner_border_at_the_far_right_top_side()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);
                
                viewComponent.SetSize(3, 5);
                
                viewComponent.Render();
                
                A.CallTo(() => console.WriteAt(2, 0,'╗')).MustHaveHappened();
            }
            [Fact]
            public void should_show_verticle_border_on_either_side_except_for_corners()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console, viewComponentTitle);
                
                viewComponent.SetSize(3, 5);
                
                viewComponent.Render();
                
                A.CallTo(() => console.WriteAt(0, 1,'║')).MustHaveHappened();
                A.CallTo(() => console.WriteAt(0, 2,'║')).MustHaveHappened();
                A.CallTo(() => console.WriteAt(0, 3,'║')).MustHaveHappened();
                A.CallTo(() => console.WriteAt(2, 1,'║')).MustHaveHappened();
                A.CallTo(() => console.WriteAt(2, 2,'║')).MustHaveHappened();
                A.CallTo(() => console.WriteAt(2, 3,'║')).MustHaveHappened();
            }
            [Fact]
            public void should_show_left_corner_border_char_at_bottom_left()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);

                viewComponent.SetSize(3, 5);

                viewComponent.Render();

                A.CallTo(() => console.WriteAt(0, 4,'╚')).MustHaveHappened();
            }
            [Fact]
            public void should_show_horizontal_border_across_the_bottom_but_not_at_either_end()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);

                viewComponent.SetSize(3, 5);

                viewComponent.Render();

                A.CallTo(() => console.WriteAt(1, 4,'═')).MustHaveHappened(); // Middle of the bottom border
            }
            [Fact]
            public void should_show_right_corner_border_at_the_far_right_bottom_side()
            {
                var console = A.Fake<IGameConsole>();
                var viewComponentTitle = A.Fake<IViewComponentTitle>();

                var viewComponent = new NarrativeViewComponent(console,viewComponentTitle);

                viewComponent.SetSize(3, 5);

                viewComponent.Render();

                A.CallTo(() => console.WriteAt(2, 4,'╝')).MustHaveHappened();
            }
        }
    }
    public class SetTitleSpecs
    {
        [Fact]
        public void should_set_title_on_title_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var narrativeViewComponent = new NarrativeViewComponent(console, viewComponentTitle);
            
            narrativeViewComponent.SetTitle("Title");
            
            A.CallTo(() => viewComponentTitle.SetValue("Title")).MustHaveHappened();
        }
    }
    public class SetSizeSpecs
    {
        [Fact]
        public void should_set_max_length_on_title_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var narrativeViewComponent = new NarrativeViewComponent(console, viewComponentTitle);
            
            narrativeViewComponent.SetSize(5,8);
            
            A.CallTo(() => viewComponentTitle.SetMaxLength(5)).MustHaveHappened();
        }
    }
    public class ReceivePlayerInputSpecs
    {
        
    }
}