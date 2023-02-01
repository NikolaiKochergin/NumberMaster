using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Sound;
using Source.Scripts.Services.StaticData;
using Source.Scripts.StaticData.Windows;
using Source.Scripts.UI.Elements;
using Source.Scripts.UI.Services.Windows;
using Source.Scripts.UI.Windows.GameLoop;
using Source.Scripts.UI.Windows.Shop;
using UnityEngine;

namespace Source.Scripts.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _factory;
        private readonly ISoundService _sounds;

        private Transform _uiRoot;

        public UIFactory(IGameStateMachine stateMachine, IStaticDataService staticData, IPersistentProgressService progressService, IGameFactory factory, ISoundService sounds)
        {
            _stateMachine = stateMachine;
            _staticData = staticData;
            _progressService = progressService;
            _factory = factory;
            _sounds = sounds;
        }

        public void InitUIRoot() => 
            _uiRoot = Camera.main.GetComponentInChildren<UIRoot>().transform;

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            ShopWindow window = Object.Instantiate(config.Template, _uiRoot) as ShopWindow;
            window.transform.SetAsFirstSibling();
            window.Construct(_stateMachine, _progressService, _staticData, _factory);
        }

        public void CreateGameLoopWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.GameMenu);
            GameLoopWindow window = Object.Instantiate(config.Template, _uiRoot) as GameLoopWindow;
            window.Construct(_sounds, _progressService);
        }
    }
}