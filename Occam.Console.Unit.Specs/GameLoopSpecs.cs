using FakeItEasy;
using Occam.Console.Views;
using Xunit;

namespace Occam.Console.Unit.Specs;

public class GameLoopSpecs
{
    public class RunSpecs
    {
        [Fact]
        public void should_return_true_generally()
        {
            var view = A.Fake<IMainMenuView>();
            var playerInputService = A.Fake<IPlayerInputService>();

            var loop = new GameLoop(view,playerInputService);
        
            Assert.True(loop.Run());
        }
        [Fact]
        public void should_return_false_when_the_player_quits()
        {
            var view = A.Fake<IMainMenuView>();
        
            var playerInputService = A.Fake<IPlayerInputService>();
        
            var escapeKeyInfo = new ConsoleKeyInfo('\0', ConsoleKey.Escape, false, false, false);

            A.CallTo(() => playerInputService.AwaitPlayer()).Returns(escapeKeyInfo);
        
            var loop = new GameLoop(view, playerInputService);
        
            Assert.False(loop.Run());
        }
        [Fact]
        public void view_should_receive_player_input()
        {
            var view = A.Fake<IMainMenuView>();
            var playerInputService = A.Fake<IPlayerInputService>();
    
            var loop = new GameLoop(view, playerInputService);
        
            loop.Run();

            IView? newView;
            A.CallTo(() => view.ReceivePlayerInput(new ConsoleKeyInfo(), out newView)).MustHaveHappened();
        }
        [Fact]
        public void view_should_render_on_first_run()
        {
            var view = A.Fake<IMainMenuView>();
            var playerInputService = A.Fake<IPlayerInputService>();
    
            var loop = new GameLoop(view, playerInputService);
        
            loop.Run();

            A.CallTo(() => view.Render()).MustHaveHappened();
        }
        [Fact]
        public void view_should_not_render_consistently_after_first_run()
        {
            var view = A.Fake<IMainMenuView>();
            var playerInputService = A.Fake<IPlayerInputService>();
    
            var loop = new GameLoop(view, playerInputService);
        
            loop.Run();
            A.CallTo(() => view.Render()).MustHaveHappenedOnceExactly();
            

            loop.Run();
            A.CallTo(() => view.Render()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void should_render_view_when_it_changes()
        {
            var firstView = A.Fake<IMainMenuView>();
            var secondView = A.Fake<IView>();
            
            var playerInputService = A.Fake<IPlayerInputService>();

            IView? v;

            A.CallTo(() => firstView.ReceivePlayerInput(new ConsoleKeyInfo(), out v))
                .Returns(false).Once(); 
            
            var loop = new GameLoop(firstView, playerInputService);
            
            SetupPreconditions(firstView, loop, secondView);

            //Setup
            A.CallTo(() => firstView.ReceivePlayerInput(new ConsoleKeyInfo(), out secondView)).Returns(true).Once(); 
            
            //Act
            loop.Run();
            
            //Assert
            A.CallTo(() => secondView.Render()).MustHaveHappenedOnceExactly();
            loop.Run();
            A.CallTo(() => secondView.Render()).MustHaveHappenedOnceExactly();
        }

        private static void SetupPreconditions(IMainMenuView firstView, GameLoop loop, IView secondView)
        {
            IView? v;
            //First Run
            A.CallTo(() => firstView.ReceivePlayerInput(new ConsoleKeyInfo(), out v)).Returns(false).Twice(); 
            loop.Run();
            A.CallTo(() => secondView.Render()).MustNotHaveHappened();
            
            //Second Run
            loop.Run();
            A.CallTo(() => secondView.Render()).MustNotHaveHappened();
            
        }
    }
}
