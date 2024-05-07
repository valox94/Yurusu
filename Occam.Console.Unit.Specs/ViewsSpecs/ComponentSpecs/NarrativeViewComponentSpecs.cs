using FakeItEasy;
using Occam.Console.Views.Components;
using Xunit;

namespace Occam.Console.Unit.Specs.ViewsSpecs.ComponentSpecs;


public class NarrativeViewComponentSpecs
{
    public class RenderSpecs
    {
        [Theory]
        [InlineData(0,0,0, 0)]
        [InlineData(1,1,1, 1)]
        public void Should_show_left_corner_border_char_at_origin(int xPosition, int yPosition, int expectedX, int expectedY)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle,contentComponent);
            
            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);
            
            component.Render();
            
            A.CallTo(() => console.WriteAt(expectedX, expectedY,'╔')).MustHaveHappened();
        }
        
        [Theory]
        [InlineData(0,0,1, 0)]
        [InlineData(1,1,2, 1)]
        public void Should_show_horizontal_border_across_the_top_but_not_at_either_end(int xPosition, int yPosition, int expectedX, int expectedY)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle, contentComponent);
            
            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);
            
            component.Render();
            
            A.CallTo(() => console.WriteAt(expectedX, expectedY,'═')).MustHaveHappened();
        }
        [Theory]
        [InlineData(0,0,2, 0)]
        [InlineData(1,1,3, 1)]
        public void Should_show_right_corner_border_at_the_far_right_top_side(int xPosition, int yPosition, int expectedX, int expectedY)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle, contentComponent);
            
            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);
            
            component.Render();
            
            A.CallTo(() => console.WriteAt(expectedX, expectedY,'╗')).MustHaveHappened();
        }
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        public void Should_show_verticle_border_on_either_side_except_for_corners(int xPosition, int yPosition)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            component.SetPosition(xPosition,yPosition);
            var width = 3;
            var height = 5;
            
            component.SetSize(width, height);
            
            component.Render();
            
            A.CallTo(() => console.WriteAt(xPosition, yPosition+1,'║')).MustHaveHappened();
            A.CallTo(() => console.WriteAt(xPosition, yPosition+2,'║')).MustHaveHappened();
            A.CallTo(() => console.WriteAt(xPosition, yPosition+3,'║')).MustHaveHappened();
            A.CallTo(() => console.WriteAt(xPosition+2, yPosition+1,'║')).MustHaveHappened();
            A.CallTo(() => console.WriteAt(xPosition+2, yPosition+2,'║')).MustHaveHappened();
            A.CallTo(() => console.WriteAt(xPosition+2, yPosition+3,'║')).MustHaveHappened();
        }
        
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        public void Should_show_left_corner_border_char_at_bottom_left(int xPosition, int yPosition)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle, contentComponent);

            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);

            component.Render();

            A.CallTo(() => console.WriteAt(0+xPosition, 4+yPosition,'╚')).MustHaveHappened();
        }
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        public void Should_show_horizontal_border_across_the_bottom_but_not_at_either_end(int xPosition, int yPosition)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle, contentComponent);

            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);

            component.Render();

            A.CallTo(() => console.WriteAt(1+xPosition, 4+yPosition,'═')).MustHaveHappened(); // Middle of the bottom border
        }
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        public void Should_show_right_corner_border_at_the_far_right_bottom_side(int xPosition, int yPosition)
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console,viewComponentTitle,contentComponent);

            component.SetPosition(xPosition,yPosition);
            component.SetSize(3, 5);

            component.Render();

            A.CallTo(() => console.WriteAt(2+xPosition, 4+yPosition,'╝')).MustHaveHappened();
        }
        
        [Fact]
        public void Should_render_content()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();
            var viewComponent = new NarrativeViewComponent(console,viewComponentTitle,contentComponent);

            viewComponent.SetSize(3, 5);
            viewComponent.SetTitle("Title");
            viewComponent.SetContent("Content");
            viewComponent.Render();

            
            A.CallTo(() => contentComponent.Render()).MustHaveHappened();
        }
    }
    public class SetTitleSpecs
    {
        [Fact]
        public void Should_set_title_on_title_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var narrativeViewComponent = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            narrativeViewComponent.SetTitle("Title");
            
            A.CallTo(() => viewComponentTitle.SetValue("Title")).MustHaveHappened();
        }
        [Fact]
        public void Should_set_position_on_title_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var title = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, title,contentComponent);
            
            component.SetPosition(2,2);
            component.SetTitle("Title");
            
            A.CallTo(() => title.SetPosition(2,2)).MustHaveHappened();
        }
        [Fact]
        public void Should_set_max_length_on_title_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var narrativeViewComponent = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            narrativeViewComponent.SetSize(5,8);
            narrativeViewComponent.SetTitle("title");
            
            A.CallTo(() => viewComponentTitle.SetMaxLength(5)).MustHaveHappened();
        }
    }
    public class SetSizeSpecs
    {

    }

    public class SetContentSpecs
    {
        [Fact]
        public  void Should_set_content_on_content_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var narrativeViewComponent = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            narrativeViewComponent.SetContent("Content");
            
            A.CallTo(() => contentComponent.SetContent("Content")).MustHaveHappened();
        }
        [Fact]
        public  void Should_set_position_on_content_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            component.SetPosition(5, 10);
            component.SetSize(10, 20);
            component.SetContent("Content");
            
            A.CallTo(() => contentComponent.SetPosition( A<int>.Ignored,A<int>.Ignored)).MustHaveHappened();
        }
        [Fact]
        public  void Should_set_position_with_padding()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            component.SetPosition(5, 10);
            component.SetSize(10, 20);
            component.SetContent("Content");
            
            A.CallTo(() => contentComponent.SetPosition( 6,11)).MustHaveHappened();
        }
        [Fact]
        public void Should_set_size_on_content_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            component.SetPosition(5, 10);
            component.SetSize(10, 20);
            component.SetContent("Content");
            
            A.CallTo(() => contentComponent.SetSize( A<int>.Ignored,A<int>.Ignored)).MustHaveHappened();
        }
        [Fact]
        public void Should_set_size_of_content_smaller_than_itself()
        {
            var console = A.Fake<IGameConsole>();
            var viewComponentTitle = A.Fake<IViewComponentTitle>();
            var contentComponent = A.Fake<IContentViewComponent>();

            var component = new NarrativeViewComponent(console, viewComponentTitle,contentComponent);
            
            component.SetPosition(5, 10);
            component.SetSize(10, 20);
            component.SetContent("Content");
            
            A.CallTo(() => contentComponent.SetSize( 8,18)).MustHaveHappened();
        }
    }
    
    public class ReceivePlayerInputSpecs
    {
        
    }
}