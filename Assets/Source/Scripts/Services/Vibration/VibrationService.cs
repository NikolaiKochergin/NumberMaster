using Source.Scripts.Plugins.Vibration;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        private readonly IPersistentProgressService _progressService;
#if UNITY_WEBGL && !UNITY_EDITOR
        public bool CanVibrate => VibrationAPI.CanVibrate();
#else
        public bool CanVibrate => true;
#endif
        public bool IsVibrationOn => _progressService.Progress.GameSettings.IsVibrationOn;

        public VibrationService(IPersistentProgressService progressService) => 
            _progressService = progressService;

        public void Vibrate()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if(CanVibrate && IsVibrationOn)
                VibrationAPI.Vibrate(_progressService.Progress.GameSettings.VibrationTime);
#endif
        }

        public void SetVibration(bool isPossible) => 
            _progressService.Progress.GameSettings.IsVibrationOn = isPossible;

        public void SetVibrationDuration(int milliseconds)
        {
            if(milliseconds < 0)
                return;
            
            _progressService.Progress.GameSettings.VibrationTime = milliseconds;
        }
    }
}
