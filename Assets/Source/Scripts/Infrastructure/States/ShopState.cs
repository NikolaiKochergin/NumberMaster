using Source.Scripts.Services.SaveLoad;
using Source.Scripts.UI.Services.Windows;

namespace Source.Scripts.Infrastructure.States
{
    public class ShopState : IState
    {
        private readonly IWindowService _windowService;
        private readonly ISaveLoadService _saveLoadService;

        public ShopState(IWindowService windowService, ISaveLoadService saveLoadService)
        {
            _windowService = windowService;
            _saveLoadService = saveLoadService;
        }

        public void Enter() =>
            _windowService.Open(WindowId.Shop);

        public void Exit() => 
            _saveLoadService.SaveProgress();
    }
}