using System;

namespace Source.Scripts.Services.Ads
{
    public interface IAdsService : IService
    {
        void ShowInterstitial(Action onShownCallback);
        void ShowRewardedVideo(Action onRewardedCallback = null);
    }
}