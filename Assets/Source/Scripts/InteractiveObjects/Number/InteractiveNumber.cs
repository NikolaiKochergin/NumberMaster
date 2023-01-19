using System;
using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
    [SelectionBase]
    public class InteractiveNumber : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private InteractiveNumberView _interactiveNumberView;
        [SerializeField] private int _value;

        private void Awake()
        {
            _interactiveNumberView.SetValue(_value);
            _triggerObserver.TriggerEnter += AffectPlayer;
        }

        private void OnDestroy() => 
            _triggerObserver.TriggerEnter -= AffectPlayer;

        private void AffectPlayer(Collider other)
        {
            if (!other.TryGetComponent(out PlayerNumber playerNumber)) return;
            if (playerNumber.Current >= _value)
            {
                playerNumber.TakeNumber(_value);
                Die();
            }
            else
            {
                Debug.Log("Player Die");
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
#if UNITY_EDITOR
        private void OnValidate() => 
            _interactiveNumberView.SetValue(_value);
#endif
    }
}
