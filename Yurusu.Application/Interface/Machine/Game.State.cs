using Yurusu.UI.Audio.Typing;

namespace Yurusu.Application.Interface.Machine;


public partial class GameInterfaceMachine
{
    public interface IGameState
    {
        void SetMachine(IGameInterface machine);
        Task DisplayAsync(string[] message);
        void TransitionToIntroState();
    }
    
    public abstract class GameState : IGameState
    {
        protected IGameInterface Machine;
        protected readonly ITypingAudio TypingAudio;
        
        protected GameState(ITypingAudio typingAudio)
        {
            TypingAudio = typingAudio;
        }

        public void SetMachine(IGameInterface machine)
        {
            Machine = machine;
        }

        public abstract Task DisplayAsync(string[] message);
        public void TransitionToIntroState()
        {
            Machine.InternalState = new IntroGameState(TypingAudio);
        }
    }
}