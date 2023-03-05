using System;
using Source.Scripts.Services.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Settings
{
    public class LanguageToggle : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private LanguageType _languageType;
        
        public LanguageType LanguageType => _languageType;

        public event Action<LanguageType> LanguageSet;

        private void Awake() => 
            _toggle.onValueChanged.AddListener(OnToggleClicked);

        public void SetToggle(bool isOn) => 
            _toggle.isOn = isOn;

        private void OnToggleClicked(bool isOn)
        {
            if(isOn)
                LanguageSet?.Invoke(_languageType);
        }
    }
}
