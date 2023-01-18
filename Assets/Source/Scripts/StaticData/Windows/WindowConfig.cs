using System;
using Source.Scripts.UI.Services.Windows;
using Source.Scripts.UI.Windows;

namespace Source.Scripts.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Template;
    }
}