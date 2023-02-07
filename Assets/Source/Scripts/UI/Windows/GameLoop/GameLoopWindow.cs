using Source.Scripts.Analytics;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.Sound;
using Source.Scripts.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public sealed class GameLoopWindow : WindowBase
    {
        [SerializeField] private Counter _softCounter;
        [SerializeField] private Counter _levelCounter;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private Button _rewardButton;
        [SerializeField] private Button _rewardOfferButton;

        private ISoundService _sounds;
        private IAdsService _adsService;
        private IAnalyticService _analytic;
        private ISaveLoadService _saveLoadService;
        
        public void Construct(
            ISoundService sounds, 
            IPersistentProgressService progressService, 
            IAdsService adsService, 
            IAnalyticService analytic, 
            ISaveLoadService saveLoadService)
        {
            _sounds = sounds;
            _adsService = adsService;
            _analytic = analytic;
            _saveLoadService = saveLoadService;
            base.Construct(progressService);
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            RefreshCurrentLevelNumberText();
            RefreshSoftValueText();
            RefreshSoundButtonView();
        }

        protected override void SubscribeUpdates()
        {
            Progress.Soft.Changed += RefreshSoftValueText;
            Progress.GameSettings.Changed += RefreshSoundButtonView;
            _soundButton.Button.onClick.AddListener(OnSoundButtonClick);
            _rewardOfferButton.onClick.AddListener(OnRewardOfferButtonClick);
            _rewardButton.onClick.AddListener(OnRewardButtonCLick);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            Progress.Soft.Changed -= RefreshSoftValueText;
            Progress.GameSettings.Changed -= RefreshSoundButtonView;
            _soundButton.Button.onClick.RemoveListener(OnSoundButtonClick);
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

        private void OnSoundButtonClick()
        {
            if(Progress.GameSettings.IsMusicOn)
                _sounds.Mute();
            else
                _sounds.UnMute();
        }

        private void RefreshSoftValueText() => 
            _softCounter.SetText(Progress.Soft.Collected);

        private void RefreshCurrentLevelNumberText() => 
            _levelCounter.SetText(Progress.World.DisplayedLevel);

        private void RefreshSoundButtonView()
        {
            if(Progress.GameSettings.IsMusicOn)
                _soundButton.SetUnMuteView();
            else
                _soundButton.SetMuteView();
        }
    }
}