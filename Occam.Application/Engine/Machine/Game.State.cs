using Occam.Application.Interface.Machine;

namespace Occam.Application.Engine.Machine;

public partial class GameEngineMachine : IGameEngine
{
    public interface IGameState
    {
        Task RunAsync();
        public void SetMachine(IGameEngine machine);
        void TransitionToMenuState();
    }

    public abstract class GameState : IGameState
    {
        protected IGameEngine Machine { get; private set; }

        public void SetMachine(IGameEngine machine) { Machine = machine; }
        
        public virtual Task RunAsync() { return Task.CompletedTask; }
        
        public virtual void TransitionToMenuState() { }
    }
}