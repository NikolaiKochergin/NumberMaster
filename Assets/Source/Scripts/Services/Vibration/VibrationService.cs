using Source.Scripts.Plugins.Vibration;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        private readonly IPersistentProgressService _progressService;
        public bool CanVibrate { get; private set; }
        public bool IsVibrationOn => _progressService.Progress.GameSettings.IsVibrationOn;

        public VibrationService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
#if UNITY_WEBGL && !UNITY_EDITOR
            CanVibrate = VibrationAPI.CanVibrate();
#elif UNITY_EDITOR
            CanVibrate = true;
#endif
        }

        public void Vibrate()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if(IsVibrationOn)
                VibrationAPI.Vibrate(_progressService.Progress.GameSettings.VibrationDuration);
#endif
        }

        public void Vibrate(int[] pattern)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if(IsVibrationOn)
                VibrationAPI.Vibrate(pattern);
#endif
        }

        public void SetVibration(bool isPossible) => 
            _progressService.Progress.GameSettings.IsVibrationOn = isPossible;

        public void SetVibrationDuration(int milliseconds)
        {
            if(milliseconds < 0)
                return;
            
            _progressService.Progress.GameSettings.VibrationDuration = milliseconds;
        }
    }
}
