using Source.Scripts.Infrastructure;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Sound
{
    public class SoundService : ISoundService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly Sounds _sounds;

        public bool IsMusicOn => _progressService.Progress.GameSettings.IsMusicOn;

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

        public void AdsMute() => 
            _sounds.Off();

        public void AdsUnMute()
        {
            if(_progressService.Progress.GameSettings.IsMusicOn)
                _sounds.On();
        }

        public void SetVolume(float value)
        {
            _sounds.SetVoulume(value);
            _progressService.Progress.GameSettings.Volume = value;
        }
    }
}