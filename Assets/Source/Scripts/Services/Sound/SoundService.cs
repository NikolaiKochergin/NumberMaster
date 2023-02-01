using Source.Scripts.Infrastructure;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Sound
{
    public class SoundService : ISoundService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly Sounds _sounds;

        public SoundService(IGameFactory factory, IPersistentProgressService progressService)
        {
            _progressService = progressService;
            _sounds = factory.CreateSounds();
        }

        public void Mute()
        {
            _sounds.Off();
            _progressService.Progress.GameSettings.IsMusicOn = false;
        }

        public void UnMute()
        {
            _sounds.On();
            _progressService.Progress.GameSettings.IsMusicOn = true;
        }
    }
}