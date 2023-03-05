using Source.Scripts.Analytics;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.UI.Elements;
using Source.Scripts.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public sealed class GameLoopWindow : WindowBase
    {
        [SerializeField] private Counter _softCounter;
        [SerializeField] private Counter _levelCounter;
        [SerializeField] private Button _rewardButton;
        [SerializeField] private Button _rewardOfferButton;
        [SerializeField] private OpenWindowButton _settingsButton;
        [SerializeField] private OpenWindowButton _leaderboardButton;

        private IAdsService _adsService;
        private IAnalyticService _analytic;
        private ISaveLoadService _saveLoadService;
        
        public void Construct(
            IPersistentProgressService progressService,
            IAdsService adsService,
            IAnalyticService analytic,
            ISaveLoadService saveLoadService, 
            IWindowService windowService)
        {
            _adsService = adsService;
            _analytic = analytic;
            _saveLoadService = saveLoadService;
            _settingsButton.Construct(windowService);
            _leaderboardButton.Construct(windowService);
            base.Construct(progressService);
            
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            RefreshCurrentLevelNumberText();
            RefreshSoftValueText();
        }

        protected override void SubscribeUpdates()
        {
            Progress.Soft.Changed += RefreshSoftValueText;
            _rewardOfferButton.onClick.AddListener(OnRewardOfferButtonClick);
            _rewardButton.onClick.AddListener(OnRewardButtonCLick);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            Progress.Soft.Changed -= RefreshSoftValueText;
            _rewardOfferButton.onClick.RemoveListener(OnRewardOfferButtonClick);
            _rewardButton.onClick.RemoveListener(OnRewardButtonCLick);
        }

        private void OnRewardButtonCLick()
        {
            _adsService.ShowRewardedVideo(() =>
                {
                    Progress.Soft.Collected += 500;
                    _analytic.SendEventOnResourceReceived(
                        AnalyticNames.Soft,
                        500,
                        AnalyticNames.RewardAd,
                        AnalyticNames.Shop);
                    _analytic.SendEventOnClick(AnalyticNames.RewardAd);
                    _saveLoadService.SaveProgress();
                });
        }

        private void OnRewardOfferButtonClick() => 
            _analytic.SendEventOnOffer(AnalyticNames.RewardAd);

        private void RefreshSoftValueText() => 
            _softCounter.SetText(Progress.Soft.Collected);

        private void RefreshCurrentLevelNumberText() => 
            _levelCounter.SetText(Progress.World.DisplayedLevel);
    }
}