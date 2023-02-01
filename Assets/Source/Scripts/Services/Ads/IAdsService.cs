using System;

namespace Source.Scripts.Services.Ads
{
    public interface IAdsService : IService
    {
        void ShowInterstitial(Action onCloseCallback = null);
        void ShowRewardedVideo(Action onRewardedCallback = null);
    }
}