using Source.Scripts.UI.Services.Windows;

namespace Source.Scripts.Infrastructure.States
{
    public class ShopState : IState
    {
        private readonly IWindowService _windowService;

        public ShopState(IWindowService windowService) => 
            _windowService = windowService;

        public void Enter() =>
            _windowService.Open(WindowId.Shop);

        public void Exit()
        {
        }
    }
}