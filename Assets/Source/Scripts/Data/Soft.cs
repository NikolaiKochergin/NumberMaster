using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class Soft
    {
        [SerializeField] private int _collected = 10000;
        
        public int Collected
        {
            get => _collected;
            set
            {
                if (value == _collected) 
                    return;
                
                _collected = value;
                Changed?.Invoke();
            }
        }

        public event Action Changed;
    }
}