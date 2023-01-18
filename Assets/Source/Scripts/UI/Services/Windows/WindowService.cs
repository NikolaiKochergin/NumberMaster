using Source.Scripts.UI.Services.Factory;

namespace Source.Scripts.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowId windowId)
        {
            switch(windowId)
            {
                case WindowId.None:
                    break;
                case WindowId.Shop:
                    _uiFactory.CreateShop();
                    break;
                case WindowId.GameMenu:
                    _uiFactory.CreateGameLoopWindow();
                    break;
            }
        }
    }
}