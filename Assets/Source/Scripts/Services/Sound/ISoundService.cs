namespace Source.Scripts.Services.Sound
{
    public interface ISoundService : IService
    {
        void Mute();
        void UnMute();
        void AdsMute();
        void AdsUnMute();
        void SetVolume(float value);
        bool IsMusicOn { get; }
    }
}