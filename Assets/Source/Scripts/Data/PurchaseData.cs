using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PurchaseData
    {
        [SerializeField] private int _startNumberCount = 0;
        [SerializeField] private int _incomeLevelCount = 0;


        public int StartNumberCount
        {
            get => _startNumberCount;
            set
            {
                if(value == _startNumberCount)
                    return;

                _startNumberCount = value;
                Changed?.Invoke();
            }
        }

        public int IncomeLevelCount
        {
            get => _incomeLevelCount;
            set
            {
                if(value == _incomeLevelCount)
                    return;

                _incomeLevelCount = value;
                Changed?.Invoke();
            }
        }

        public event Action Changed;
    }
}