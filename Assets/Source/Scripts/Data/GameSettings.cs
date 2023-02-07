using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private bool _isMusicOn = true;

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

        public event Action Changed;
    }
}