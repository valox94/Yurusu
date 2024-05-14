using Xunit;
using FakeItEasy;
using MediatR;
using Occam.UI;

namespace Occam.Application.Unit.Specs;

public class RunApplicationSpecs
{
    [Fact]
    public async Task Should_show_welcome_message_When_handling_request()
    {
        var @interface = A.Fake<IPlayerInterface>();
        var handler = new RunApplicationHandler(@interface);
        var request = new RunApplication.Request();
        var response = await handler.Handle(request, default);
        
        A.CallTo(() => @interface.ShowMessageAsync("Welcome to Occam!")).MustHaveHappened();
    }
    [Fact]
    public async Task Should_wait_for_player_acknowledgement_After_showing_message()
    {
        var @interface = A.Fake<IPlayerInterface>();
        var handler = new RunApplicationHandler(@interface);
        var request = new RunApplication.Request();
        var response = await handler.Handle(request, default);
        
        A.CallTo(() => @interface.WaitForPlayerAcknowledgementAsync()).MustHaveHappened();
    }
}





