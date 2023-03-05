using System.Collections.Generic;
using Agava.YandexGames;
using Source.Scripts.Analytics;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.Authorization;
using Source.Scripts.Services.IAP;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.Leaderboard;
using Source.Scripts.Services.Localization;
using Source.Scripts.Services.Pause;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.Sound;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services.Factory;
using Source.Scripts.UI.Services.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        private IStaticDataService _staticData;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
#if UNITY_EDITOR
            if(SceneManager.GetActiveScene().buildIndex != 0)
                PlayerPrefs.SetInt("SceneToLoad", SceneManager.GetActiveScene().buildIndex);
#endif
            _sceneLoader.Load(_staticData.ForSceneName(0), onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticDataService();
            
            _services.RegisterSingle(InputService());
            _services.RegisterSingle(AnalyticService());
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<IGamePauseService>(new GamePause());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IAuthorizationService>(new AuthorizationService());

            _services.RegisterSingle<ILocalizationService>(new LocalizationService(
                _services.Single<IPersistentProgressService>(),
                _services.Single<IStaticDataService>()));
            
            _services.RegisterSingle<ILeaderboardService>(new LeaderboardService(
                _services.Single<IStaticDataService>().ForLeaderboardName(),
                _services.Single<IAuthorizationService>()));
            

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IGameStateMachine>(),
                _services.Single<IInputService>(),
                _services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>()));
            
            _services.RegisterSingle<IIAPService>(new IAPService(
                _services.Single<IStaticDataService>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>(),
                _services.Single<IAnalyticService>()));

            _services.RegisterSingle<ISoundService>(new SoundService(
                _services.Single<IGameFactory>(),
                _services.Single<IPersistentProgressService>()));
            
            _services.RegisterSingle<IAdsService>(new AdsService(
                _services.Single<IGamePauseService>(),
                _services.Single<ISoundService>()));
            
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));

            _services.RegisterSingle<IUIFactory>(new UIFactory(
                _services.Single<IGameStateMachine>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<ISoundService>(),
                _services.Single<IAdsService>(),
                _services.Single<IAnalyticService>(),
                _services.Single<ISaveLoadService>(),
                _services.Single<IIAPService>(),
                _services.Single<ILeaderboardService>(),
                _services.Single<IAuthorizationService>(),
                out IWindowService windowService));
            
            _services.RegisterSingle<IWindowService>(windowService);
        }

        private void RegisterStaticDataService()
        {
            _staticData = new StaticDataService();
            _staticData.Load();
            _services.RegisterSingle(_staticData);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private IAnalyticService AnalyticService() =>
            new AnalyticService(new List<IAnalytic>
            {
#if GAME_ANALYTICS
                new GameAnalyticsAnalytic(),
#endif
#if YANDEX_METRICA && !UNITY_EDITOR
                new YandexMetricaAnalytic(),
#endif
            });


#if UNITY_EDITOR
        private IInputService InputService() =>
            Application.isEditor
                ? (IInputService) new StandaloneInputService(
                    _services.Single<IStaticDataService>().ForMouseSensitivity(),
                    _services.Single<IStaticDataService>().ForKeyboardSensitivity())
                : new MobileInputService(_services.Single<IStaticDataService>().ForMouseSensitivity());
#else
        private IInputService InputService() =>
            Device.Type == Agava.YandexGames.DeviceType.Desktop
                ? (IInputService) new StandaloneInputService(
                    _services.Single<IStaticDataService>().ForMouseSensitivity(),
                    _services.Single<IStaticDataService>().ForKeyboardSensitivity())
                : new MobileInputService(_services.Single<IStaticDataService>().ForMouseSensitivity());
#endif
    }
}