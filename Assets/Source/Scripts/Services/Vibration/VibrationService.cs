using Source.Scripts.Plugins.Vibration;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Vibration
{
    public class VibrationService : IVibrationService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly bool _canVibrate;

        public bool IsVibrationOn => _progressService.Progress.GameSettings.IsVibrationOn;

        public VibrationService(IPersistentProgressService progressService)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            _canVibrate = VibrationAPI.CanVibrate();
#endif
            _progressService = progressService;
        }

        public void Vibrate()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if(_canVibrate && IsVibrationOn)
                VibrationAPI.Vibrate(_progressService.Progress.GameSettings.VibrationTime);
#endif
        }

        public void SetVibration(bool isPossible) => 
            _progressService.Progress.GameSettings.IsVibrationOn = isPossible;

        public void SetVibrationTime(int milliseconds)
        {
            if(milliseconds < 0)
                return;
            
            _progressService.Progress.GameSettings.VibrationTime = milliseconds;
        }
    }
}
