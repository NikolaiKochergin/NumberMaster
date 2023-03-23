namespace Source.Scripts.Services.Vibration
{
    public interface IVibrationService : IService
    {
        bool IsVibrationOn { get; }
        void Vibrate();
        void SetVibration(bool isPossible);
        void SetVibrationTime(int milliseconds);
    }
}