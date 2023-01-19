using Source.Scripts.StaticData.Windows;
using Source.Scripts.UI.Services.Windows;

namespace Source.Scripts.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        float ForPlayerSpeed();
        float ForMouseSensitivity();
        float ForKeyboardSensitivity();
        WindowConfig ForWindow(WindowId windowId);
        string ForSceneName(int index);
        int ForRepeatLevelNumber();
    }
}