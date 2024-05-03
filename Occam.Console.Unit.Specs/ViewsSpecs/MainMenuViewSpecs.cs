using FakeItEasy;
using Occam.Console.Views;
using Occam.Console.Views.Components;
using Xunit;

namespace Occam.Console.Unit.Specs.ViewsSpecs;

public class MainMenuViewSpecs
{
    // public class ReceivePlayerInputSpecs
    // {
    //     [Fact]
    //     public void should_do_something()
    //     {
    //         // Arrange
    //         // Act
    //         // Assert
    //     }
    // }
    public class RenderSpecs
    {
        [Fact]
        public void should_render_narrative_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var narrativeViewComponent = A.Fake<INarrativeViewComponent>();
            var mainMenuView = new MainMenuView(console, narrativeViewComponent);
            
            mainMenuView.Render();
            
            A.CallTo(() => narrativeViewComponent.Render()).MustHaveHappened();
        }
        [Fact]
        public void should_set_size_of_narrative_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var narrativeViewComponent = A.Fake<INarrativeViewComponent>();
            var mainMenuView = new MainMenuView(console, narrativeViewComponent);
            
            mainMenuView.Render();
            
            A.CallTo(() => narrativeViewComponent.SetSize(25,10)).MustHaveHappened();
        }
        [Fact]
        public void should_set_title_of_narrative_view_component()
        {
            var console = A.Fake<IGameConsole>();
            var narrativeViewComponent = A.Fake<INarrativeViewComponent>();
            var mainMenuView = new MainMenuView(console, narrativeViewComponent);
            
            mainMenuView.Render();
            
            A.CallTo(() => narrativeViewComponent.SetTitle("Narrative")).MustHaveHappened();
        }
    }
}