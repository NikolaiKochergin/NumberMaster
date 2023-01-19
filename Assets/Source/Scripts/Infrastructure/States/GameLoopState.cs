using Source.Scripts.Infrastructure.Factory;

namespace Source.Scripts.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _factory;

        public GameLoopState(IGameFactory factory) => 
            _factory = factory;

        public void Enter() => 
            _factory.Player.PlayerMove.Enable();

        public void Exit() => 
            _factory.Player.PlayerMove.Disable();
    }
}