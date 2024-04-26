using FakeItEasy;
using Xunit;

namespace Occam.Console.Unit.Specs;

public class PlayerInputServiceSpecs
{
    [Fact]
    public void should_wait_for_console_read_key_when_waiting_for_player_input()
    {
        var console = A.Fake<IGameConsole>();
        
        var playerInputService = new PlayerInputService(console);
        
        playerInputService.AwaitPlayer();
        
        A.CallTo(() => console.ReadKey()).MustHaveHappened();
    }
}