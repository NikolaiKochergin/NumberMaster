using System;
using UnityEngine;

namespace Source.Scripts.Services.IAP
{
    [Serializable]
    public class PurchaseConfig
    {
        [SerializeField] private PurchaseType _type;
        [SerializeField] [Min(0)] private int _basePrice = 100;
        [SerializeField] [Min(0)] private float _salableValue = 0.1f;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;

        public PurchaseType Type => _type;
        public int BasePrice => _basePrice;
        public float SalableValue => _salableValue;
        public Sprite Icon => _icon;
        public string Description => _description;
    }
}