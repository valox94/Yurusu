using Occam.Application.Interface.Machine;

namespace Occam.Application.Engine.Machine;

public partial class GameEngineMachine
{
    public async Task RunAsync()
    {
        await InternalState.RunAsync();
    }

    public partial class IntroGameState : GameState
    {
        private readonly string[] _introText = new string[]
        {
            "Hello adventurer! Welcome to the Yurusu...",
            "",
            "",
            "Yurusu is a text-based adventure game where you will be able to explore the world of Yurusu.",
            "You will be able to interact with the world and its inhabitants, and make choices that will affect the outcome of your adventure.",
            "",
            "",
            "Press any key to start your adventure..."
        };
        
        private readonly IGameInterface _interface;
        
        public IntroGameState(IGameInterface @interface)
        {
            _interface = @interface;
        }
        
        public override async Task RunAsync()
        {
            _interface.SetToIntroState();
            _interface.Initialize();
            await _interface.DisplayAsync(_introText);
            Console.ReadKey(true);
            Machine.SetToMenuState();
        }
    }
    public partial class GameMenuState : GameState
    {
        private readonly string[] _menu = new string[]
        {
            "MAIN MENU",
        };

        public override async Task RunAsync()
        {
            _interface.SetToMenuState();
            _interface.Initialize();
            await _interface.DisplayAsync(_menu);
            Console.ReadKey(true);
            //TODO: Implement menu options
        }
    }
}