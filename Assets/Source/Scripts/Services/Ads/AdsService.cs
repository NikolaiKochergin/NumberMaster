using Source.Scripts.Services.Pause;
using Source.Scripts.Services.Sound;

namespace Source.Scripts.Services.Ads
{
    public class AdsService : IAdsService
    {
        private readonly IGamePauseService _gamePause;
        private readonly ISoundService _soundService;

        public AdsService(IGamePauseService gamePause, ISoundService soundService)
        {
            _gamePause = gamePause;
            _soundService = soundService;
        }
    }
}