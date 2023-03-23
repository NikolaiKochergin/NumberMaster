namespace Source.Scripts.Services.Vibration
{
    public interface IVibrationService : IService
    {
        bool IsVibrationOn { get; }
        bool CanVibrate { get; }
        void Vibrate();
        void SetVibration(bool isPossible);
        void SetVibrationDuration(int milliseconds);
    }
}