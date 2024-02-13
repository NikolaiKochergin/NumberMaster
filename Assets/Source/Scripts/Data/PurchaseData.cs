using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PurchaseData
    {
        [SerializeField] private int _startNumberCount = 0;
        [SerializeField] private int _incomeLevelCount = 0;

        [SerializeField] private SerializableDictionary<string, int> _something = new SerializableDictionary<string, int>();

        public SerializableDictionary<string, int> Something => _something;

        public List<int> AnotherPurchases = new List<int>
        {
            135
        };


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