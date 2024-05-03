namespace Occam.Console.Views.Components;

public interface  INarrativeViewComponent : IViewComponent { }

public class NarrativeViewComponent : ViewComponent, INarrativeViewComponent
{
    public NarrativeViewComponent(IGameConsole console, IViewComponentTitle viewComponentTitle) 
        : base(console, viewComponentTitle)
    {
    }
}