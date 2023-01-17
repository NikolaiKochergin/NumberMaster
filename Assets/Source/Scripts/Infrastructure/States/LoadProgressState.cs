using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string GameSceneName = "001_Level_1";
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadProgress;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadProgress)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadProgress = saveLoadProgress;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _stateMachine.Enter<LoadLevelState, string>(GameSceneName);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                _saveLoadProgress.LoadProgress()
                ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            PlayerProgress progress = new PlayerProgress(initialLevel: GameSceneName);


            return progress;
        }
    }
}