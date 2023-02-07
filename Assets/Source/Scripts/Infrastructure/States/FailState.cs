using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.Infrastructure.States
{
    public class FailState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticData;
        private readonly IAnalyticService _analytic;

        public FailState(
            IGameStateMachine stateMachine, 
            SceneLoader sceneLoader, 
            IPersistentProgressService progressService,
            IStaticDataService staticData,
            IAnalyticService analytic)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _progressService = progressService;
            _staticData = staticData;
            _analytic = analytic;
        }
        
        public void Enter()
        {
            _analytic.SendEventOnFail(_progressService.Progress.World.DisplayedLevel);
            _sceneLoader.Reload(OnLoaded);
        }

        private void OnLoaded() => 
            _stateMachine.Enter<LoadLevelState, string>(_staticData.ForSceneName(_progressService.Progress.World.CurrentLevel));

        public void Exit()
        {
        }
    }
}