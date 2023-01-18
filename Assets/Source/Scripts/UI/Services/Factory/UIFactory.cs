using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using Source.Scripts.StaticData.Windows;
using Source.Scripts.UI.Elements;
using Source.Scripts.UI.Services.Windows;
using Source.Scripts.UI.Windows.GameMenu;
using Source.Scripts.UI.Windows.Shop;
using UnityEngine;

namespace Source.Scripts.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;

        private Transform _uiRoot;

        public UIFactory( IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _staticData = staticData;
            _progressService = progressService;
        }

        public void InitUIRoot() => 
            _uiRoot = Camera.main.GetComponentInChildren<UIRoot>().transform;

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            ShopWindow window = Object.Instantiate(config.Template, _uiRoot) as ShopWindow;
            window.Construct(_progressService);
        }

        public void CreateGameMenu()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.GameMenu);
            GameMenuWindow window = Object.Instantiate(config.Template, _uiRoot) as GameMenuWindow;
            window.Construct(_progressService);
        }
    }
}