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

        public FailState(IGameStateMachine stateMachine, SceneLoader sceneLoader, IPersistentProgressService progressService,
            IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _progressService = progressService;
            _staticData = staticData;
        }
        
        public void Enter() => 
            _sceneLoader.Reload(OnLoaded);

        private void OnLoaded() => 
            _stateMachine.Enter<LoadLevelState, string>(_staticData.ForSceneName(_progressService.Progress.World.CurrentLevel));

        public void Exit()
        {
        }
    }
}