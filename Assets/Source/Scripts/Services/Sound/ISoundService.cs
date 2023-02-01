using Source.Scripts.Infrastructure;

namespace Source.Scripts.Services.Sound
{
    public interface ISoundService : IService
    {
        void Mute();
        void UnMute();
        Sounds Sounds { get; }
    }
}