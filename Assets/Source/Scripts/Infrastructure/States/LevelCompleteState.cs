using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Infrastructure.States
{
    public class LevelCompleteState : IState
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _factory;

        public LevelCompleteState(IPersistentProgressService progressService, IGameFactory factory)
        {
            _progressService = progressService;
            _factory = factory;
        }

        public void Enter()
        {
            _progressService.Progress.Soft.Add(_factory.Player.PlayerNumber.Current);
        }

        public void Exit()
        {
        }
    }
}