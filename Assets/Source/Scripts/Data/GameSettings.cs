using System;
using Source.Scripts.Services.Localization;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class GameSettings
    {
        public LanguageType Localization = LanguageType.None;
        public float Volume = 1;
        public int VibrationTime = 100;
        [SerializeField] private bool _isMusicOn = true;
        [SerializeField] private bool _isVibrationOn = true;

        public bool IsMusicOn
        {
            get => _isMusicOn;
            set
            {
                if(value == _isMusicOn)
                    return;

                _isMusicOn = value;
                Changed?.Invoke();
            }
        }
        
        public bool IsVibrationOn
        {
            get => _isVibrationOn;
            set
            {
                if(value == _isVibrationOn)
                    return;

                _isVibrationOn = value;
                Changed?.Invoke();
            }
        }

        public event Action Changed;
    }
}