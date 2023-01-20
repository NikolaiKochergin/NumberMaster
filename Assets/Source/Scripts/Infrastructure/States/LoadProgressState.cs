using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadProgress;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService,
            IStaticDataService staticDataService, ISaveLoadService saveLoadProgress)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _saveLoadProgress = saveLoadProgress;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
#if UNITY_EDITOR
            if(PlayerPrefs.GetString("SceneToLoad") != _staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel) &&
               PlayerPrefs.GetString("SceneToLoad") != _staticDataService.ForSceneName(0))
                _stateMachine.Enter<LoadLevelState, string>(PlayerPrefs.GetString("SceneToLoad"));
            else
#endif
                _stateMachine.Enter<LoadLevelState, string>(_staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel));
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                _saveLoadProgress.LoadProgress()
                ?? new PlayerProgress();
        }
    }
}