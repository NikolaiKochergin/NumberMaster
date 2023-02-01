using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Sound;
using Source.Scripts.UI.Elements;
using UnityEngine;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public sealed class GameLoopWindow : WindowBase
    {
        [SerializeField] private Counter _softCounter;
        [SerializeField] private Counter _levelCounter;
        [SerializeField] private SoundButton _soundButton;

        private ISoundService _sounds;
        
        public void Construct(ISoundService sounds, IPersistentProgressService progressService)
        {
            _sounds = sounds;
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
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            Progress.Soft.Changed -= RefreshSoftValueText;
            Progress.GameSettings.Changed -= RefreshSoundButtonView;
            _soundButton.Button.onClick.RemoveListener(OnSoundButtonClick);
        }

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