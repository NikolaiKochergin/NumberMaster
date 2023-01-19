using Source.Scripts.UI.Services.Factory;

namespace Source.Scripts.Infrastructure.States
{
    public class ShopState : IState
    {
        private readonly IUIFactory _uiFactory;

        public ShopState(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Enter() => 
            _uiFactory.CreateShop();

        public void Exit()
        {
        }
    }
}