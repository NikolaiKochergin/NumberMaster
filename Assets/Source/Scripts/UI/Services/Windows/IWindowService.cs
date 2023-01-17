using Source.Scripts.Services;

namespace Source.Scripts.UI.Services.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowId windowId);
    }
}