namespace Source.Scripts.Services.Sound
{
    public interface ISoundService : IService
    {
        void Mute();
        void UnMute();
    }
}