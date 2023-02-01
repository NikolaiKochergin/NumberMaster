using Source.Scripts.Infrastructure;
using Source.Scripts.Infrastructure.Factory;

namespace Source.Scripts.Services.Sound
{
    public class SoundService : ISoundService
    {
        private readonly IGameFactory _factory;
        public Sounds Sounds { get; }

        public SoundService(IGameFactory factory)
        {
            _factory = factory;
            Sounds = _factory.CreateSounds();
        }

        public void Mute() => 
            Sounds.Off();

        public void UnMute() => 
            Sounds.On();
    }
}