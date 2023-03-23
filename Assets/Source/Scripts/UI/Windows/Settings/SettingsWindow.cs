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
        [SerializeField] private Button _vibrationOnesButton;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private EnableVibrationButton _enableVibrationButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Slider _vibrationSlider;
        [SerializeField] private LanguageToggleGroup _languageToggleGroup;
        [SerializeField] private VibrationInfo _vibrationInfo;
        
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
            _vibrationInfo.SetVibrationInfo(_vibration.IsVibrationOn);
            
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles)
                if (toggle.LanguageType == Progress.GameSettings.Localization)
                    toggle.SetToggle(true);
        }

        protected override void SubscribeUpdates()
        {
            _soundButton.Button.onClick.AddListener(OnSoundButtonClick);
            _enableVibrationButton.Button.onClick.AddListener(OnVibrationButtonClick);
            _closeButton.onClick.AddListener(Close);
            _vibrationOnesButton.onClick.AddListener(OnVibrationOnesButtonClick);
            _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
            _vibrationSlider.onValueChanged.AddListener(OnVibrationChanged);
            Progress.GameSettings.Changed += RefreshButtonsView;
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles) 
                toggle.LanguageSet += OnLanguageSet;
        }

        protected override void Cleanup()
        {
            _soundButton.Button.onClick.RemoveListener(OnSoundButtonClick);
            _enableVibrationButton.Button.onClick.RemoveListener(OnVibrationButtonClick);
            _closeButton.onClick.RemoveListener(Close);
            _vibrationOnesButton.onClick.AddListener(OnVibrationOnesButtonClick);
            _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
            _vibrationSlider.onValueChanged.RemoveListener(OnVibrationChanged);
            Progress.GameSettings.Changed -= RefreshButtonsView;
            foreach (LanguageToggle toggle in _languageToggleGroup.Toggles) 
                toggle.LanguageSet -= OnLanguageSet;
        }

        private void OnSoundButtonClick()
        {
            if(_sounds.IsMusicOn)
                _sounds.Mute();
            else
                _sounds.UnMute();
        }

        private void OnVibrationButtonClick() => 
            _vibration.SetVibration(!_vibration.IsVibrationOn);

        private void RefreshButtonsView()
        {
            if(_sounds.IsMusicOn)
                _soundButton.SetUnMuteView();
            else
                _soundButton.SetMuteView();
            
            if(_vibration.IsVibrationOn)
                _enableVibrationButton.SetOnVibrationView();
            else
                _enableVibrationButton.SetOffVibrationView();
        }

        private void OnVibrationOnesButtonClick() => 
            _vibration.Vibrate();

        private void OnVolumeChanged(float value) => 
            _sounds.SetVolume(value);

        private void OnVibrationChanged(float value) => 
            _vibration.SetVibrationDuration((int)value);

        private void OnLanguageSet(LanguageType type) => 
            _localizationService.SetLocalization(type);
    }
}
