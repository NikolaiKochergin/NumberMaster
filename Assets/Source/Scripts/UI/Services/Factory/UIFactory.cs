using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.IAP;
using Source.Scripts.Services.Leaderboard;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.Sound;
using Source.Scripts.Services.StaticData;
using Source.Scripts.StaticData.Windows;
using Source.Scripts.UI.Elements;
using Source.Scripts.UI.Services.Windows;
using Source.Scripts.UI.Windows.GameLoop;
using Source.Scripts.UI.Windows.Leaderboard;
using Source.Scripts.UI.Windows.Shop;
using UnityEngine;

namespace Source.Scripts.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        private readonly ISoundService _sounds;
        private readonly IAdsService _adsService;
        private readonly IAnalyticService _analytic;
        private readonly IIAPService _iapService;
        private readonly ILeaderboardService _leaderboardService;

        private Transform _uiRoot;
        private ISaveLoadService _saveLoad;
        private IWindowService _windowService;

        public UIFactory(IGameStateMachine stateMachine,
            IStaticDataService staticData,
            IPersistentProgressService progressService,
            ISoundService sounds,
            IAdsService adsService,
            IAnalyticService analytic,
            ISaveLoadService saveLoad,
            IIAPService iapService,
            ILeaderboardService leaderboardService,
            out IWindowService windowService)
        {
            _stateMachine = stateMachine;
            _staticData = staticData;
            _progressService = progressService;
            _sounds = sounds;
            _adsService = adsService;
            _analytic = analytic;
            _saveLoad = saveLoad;
            _iapService = iapService;
            _leaderboardService = leaderboardService;
            windowService = new WindowService(this);
            _windowService = windowService;
        }

        public void InitUIRoot() => 
            _uiRoot = Camera.main.GetComponentInChildren<UIRoot>().transform;

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            ShopWindow window = Object.Instantiate(config.Template, _uiRoot) as ShopWindow;
            window.transform.SetAsFirstSibling();
            window.Construct(_stateMachine, _progressService, _iapService);
        }

        public void CreateGameLoopWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.GameMenu);
            GameLoopWindow window = Object.Instantiate(config.Template, _uiRoot) as GameLoopWindow;
            window.Construct(_sounds, _progressService, _adsService, _analytic, _saveLoad, _windowService);
        }

        public void CreateLeaderboardWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Leaderboard);
            LeaderboardWindow window = Object.Instantiate(config.Template, _uiRoot) as LeaderboardWindow;
            window.Construct(_leaderboardService);
        }
    }
}