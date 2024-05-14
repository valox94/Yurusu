using FakeItEasy;
using Occam.UI;
using Xunit;

namespace Occam.UI.Unit.Specs;

public class PlayerInterfaceSpecs
{
    [Fact]
    public async Task Should_show_message_When_invoked()
    {
        var console = A.Fake<IGameConsole>();
        // Arrange
        var playerInterface = new PlayerInterface(console);
        var message = "Hello, World!";
        // Act
        await playerInterface.ShowMessageAsync(message);
        
        // Assert
        A.CallTo(() => console.WriteLine(message)).MustHaveHappened();
    }
    [Fact]
    public async Task Should_wait_for_player_acknowledgement_When_invoked()
    {
        var console = A.Fake<IGameConsole>();
        // Arrange
        var playerInterface = new PlayerInterface(console);
        // Act
        await playerInterface.WaitForPlayerAcknowledgementAsync();
        
        // Assert
        A.CallTo(() => console.ReadKey()).MustHaveHappened();
    }
}

