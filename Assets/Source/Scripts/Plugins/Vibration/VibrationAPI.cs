using System.Runtime.InteropServices;

namespace Source.Scripts.Plugins.Vibration
{
    public static class VibrationAPI
    {
        [DllImport("__Internal")]
        public static extern bool CanVibrate();
        
        [DllImport("__Internal")]
        public static extern void Vibrate(int time = 1000);
    }
}