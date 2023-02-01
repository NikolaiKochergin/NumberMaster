using System;
using Source.Scripts.Services.Pause;
using Source.Scripts.Services.Sound;
#if YANDEX_GAMES
using Agava.YandexGames;
#endif

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

        public void ShowInterstitial(Action onCloseCallback = null)
        {
#if UNITY_EDITOR
            onCloseCallback?.Invoke();            
#endif
#if YANDEX_GAMES && !UNITY_EDITOR
            InterstitialAd.Show(
                Pause,
                _ =>
                {
                    UnPause();
                    onCloseCallback?.Invoke();
                }, 
                _ => UnPause());
#endif
        }

        public void ShowRewardedVideo(Action onRewardedCallback = null)
        {
#if UNITY_EDITOR
            onRewardedCallback?.Invoke();            
#endif
#if YANDEX_GAMES && !UNITY_EDITOR
            VideoAd.Show(
                Pause,
                onRewardedCallback,
                UnPause,
                _ => UnPause());
#endif
        }

        private void Pause()
        {
            _gamePause.On();
            _soundService.AdsMute();
        }

        private void UnPause()
        {
            _gamePause.Off();
            _soundService.AdsUnMute();
        }
    }
}