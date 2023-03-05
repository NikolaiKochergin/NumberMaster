using Source.Scripts.Services.Localization;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Sound;
using Source.Scripts.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private LanguageToggleGroup _languageToggleGroup;
        
        private ILocalizationService _localizationService;
        private ISoundService _sounds;

        public void Construct(IPersistentProgressService progressService, 
            ILocalizationService localizationService,
            ISoundService soundService)
        {
            base.Construct(progressService);
            _localizationService = localizationService;
            _sounds = soundService;
        }

        protected override void Initialize()
        {
            RefreshSoundButtonView();
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles)
                if (toggle.LanguageType == Progress.GameSettings.Localization)
                    toggle.SetToggle(true);
        }

        protected override void SubscribeUpdates()
        {
            _soundButton.Button.onClick.AddListener(OnSoundButtonClick);
            _closeButton.onClick.AddListener(Close);
            _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
            Progress.GameSettings.Changed += RefreshSoundButtonView;
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles) 
                toggle.LanguageSet += OnLanguageSet;
        }

        protected override void Cleanup()
        {
            _soundButton.Button.onClick.RemoveListener(OnSoundButtonClick);
            _closeButton.onClick.RemoveListener(Close);
            _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
            Progress.GameSettings.Changed -= RefreshSoundButtonView;
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles) 
                toggle.LanguageSet -= OnLanguageSet;
        }
        
        private void OnSoundButtonClick()
        {
            if(Progress.GameSettings.IsMusicOn)
                _sounds.Mute();
            else
                _sounds.UnMute();
        }
        
        private void RefreshSoundButtonView()
        {
            if(Progress.GameSettings.IsMusicOn)
                _soundButton.SetUnMuteView();
            else
                _soundButton.SetMuteView();
        }

        private void OnVolumeChanged(float value)
        {
            
        }

        private void OnLanguageSet(LanguageType type) => 
            _localizationService.SetLocalization(type);
    }
}
