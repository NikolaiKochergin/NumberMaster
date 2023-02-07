using Source.Scripts.Services;

namespace Source.Scripts.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        void InitUIRoot();
        void CreateGameLoopWindow();
    }
}