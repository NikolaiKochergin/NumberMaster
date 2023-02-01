using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.Infrastructure.States
{
    public class LevelCompleteState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameFactory _factory;

        public LevelCompleteState(GameStateMachine stateMachine, IPersistentProgressService progressService, IStaticDataService staticDataService,
            ISaveLoadService saveLoadService,
            IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _factory = factory;
        }

        public void Enter()
        {
            float collected = _factory.Player.PlayerNumber.Current * (1.0f +
                                                                      (_progressService.Progress.PlayerStats
                                                                          .IncomeLevel - 1) * _staticDataService
                                                                          .ForIncomeIncrement());
            
            _progressService.Progress.Soft.Collected += (int)collected;
            SetNextLevelIndex();
            _saveLoadService.SaveProgress();
            _stateMachine.Enter<LoadLevelState, string>(_staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel));
        }

        public void Exit()
        {
        }

        private void SetNextLevelIndex()
        {
            _progressService.Progress.World.DisplayedLevel += 1;
            if (_staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel + 1) == null)
                _progressService.Progress.World.CurrentLevel = _staticDataService.ForRepeatLevelNumber();
            else
                _progressService.Progress.World.CurrentLevel += 1;
        }
    }
}