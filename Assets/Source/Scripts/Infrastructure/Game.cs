using Source.Scripts.Infrastructure.States;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine();
        }
    }
}
