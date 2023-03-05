using Source.Scripts.Data;
using Source.Scripts.Services.Localization;
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
        private readonly ILocalizationService _localizationService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService,
            IStaticDataService staticDataService, ISaveLoadService saveLoadProgress, ILocalizationService localizationService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _saveLoadProgress = saveLoadProgress;
            _localizationService = localizationService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
#if UNITY_EDITOR
            _progressService.Progress.World.CurrentLevel = PlayerPrefs.GetInt("SceneToLoad");
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
            
            _localizationService.SetLocalization(_progressService.Progress.GameSettings.Localization);
        }
    }
}