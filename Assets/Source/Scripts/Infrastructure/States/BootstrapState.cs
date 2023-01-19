using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services.Factory;
using Source.Scripts.UI.Services.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

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
            // На релизе этот кусок вырезать
            Debug.Log("На релизе этот кусок вырезать");
            PlayerPrefs.SetString("SceneToLoad", SceneManager.GetActiveScene().name);
            // ----------
            
            _sceneLoader.Load(_staticData.ForSceneName(0), onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticDataService();
            
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IGameStateMachine>(),
                _services.Single<IInputService>(),
                _services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>()));
            
            _services.RegisterSingle<IUIFactory>(new UIFactory(
                _services.Single<IGameStateMachine>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()
                ));

            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));
        }

        private void RegisterStaticDataService()
        {
            _staticData = new StaticDataService();
            _staticData.Load();
            _services.RegisterSingle(_staticData);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private IInputService InputService() =>
            Application.isEditor
                ? (IInputService) new StandaloneInputService(
                    _services.Single<IStaticDataService>().ForMouseSensitivity(),
                    _services.Single<IStaticDataService>().ForKeyboardSensitivity())
                : new MobileInputService(_services.Single<IStaticDataService>().ForMouseSensitivity());
    }
}