using Source.Scripts.Services.Localization;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Sound;
using Source.Scripts.Services.Vibration;
using Source.Scripts.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Settings
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private VibrationButton _vibrationButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Slider _vibrationSlider;
        [SerializeField] private LanguageToggleGroup _languageToggleGroup;
        
        private ILocalizationService _localizationService;
        private ISoundService _sounds;
        private IVibrationService _vibration;

        public void Construct(IPersistentProgressService progressService, 
            ILocalizationService localizationService,
            ISoundService soundService,
            IVibrationService vibration)
        {
            base.Construct(progressService);
            _localizationService = localizationService;
            _sounds = soundService;
            _vibration = vibration;
        }

        protected override void Initialize()
        {
            RefreshButtonsView();
            _volumeSlider.value = Progress.GameSettings.Volume;
            _vibrationSlider.value = Progress.GameSettings.VibrationTime;
            
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles)
                if (toggle.LanguageType == Progress.GameSettings.Localization)
                    toggle.SetToggle(true);
        }

        protected override void SubscribeUpdates()
        {
            _soundButton.Button.onClick.AddListener(OnSoundButtonClick);
            _vibrationButton.Button.onClick.AddListener(OnVibrationButtonClick);
            _closeButton.onClick.AddListener(Close);
            _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
            _vibrationSlider.onValueChanged.AddListener(OnVibrationChanged);
            Progress.GameSettings.Changed += RefreshButtonsView;
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles) 
                toggle.LanguageSet += OnLanguageSet;
        }

        protected override void Cleanup()
        {
            _soundButton.Button.onClick.RemoveListener(OnSoundButtonClick);
            _vibrationButton.Button.onClick.RemoveListener(OnSoundButtonClick);
            _closeButton.onClick.RemoveListener(Close);
            _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
            _vibrationSlider.onValueChanged.RemoveListener(OnVibrationChanged);
            Progress.GameSettings.Changed -= RefreshButtonsView;
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

        private void OnVibrationButtonClick() => 
            _vibration.SetVibration(!Progress.GameSettings.IsVibrationOn);

        private void RefreshButtonsView()
        {
            if(Progress.GameSettings.IsMusicOn)
                _soundButton.SetUnMuteView();
            else
                _soundButton.SetMuteView();
            
            if(Progress.GameSettings.IsVibrationOn)
                _vibrationButton.SetOnVibrationView();
            else
                _vibrationButton.SetOffVibrationView();
        }

        private void OnVolumeChanged(float value) => 
            _sounds.SetVolume(value);

        private void OnVibrationChanged(float value) => 
            _vibration.SetVibrationTime((int)value);

        private void OnLanguageSet(LanguageType type) => 
            _localizationService.SetLocalization(type);
    }
}
