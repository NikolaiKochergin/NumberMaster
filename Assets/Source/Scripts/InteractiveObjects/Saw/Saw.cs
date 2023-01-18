using Source.Scripts.InteractiveObjects;
using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class Saw : MonoBehaviour
    {
        [SerializeField] private DamgeSaw _damgeSaw;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += ActivateDamage;
            _triggerObserver.TriggerExit += TurnOffDamage;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= ActivateDamage;
            _triggerObserver.TriggerExit -= TurnOffDamage;
        }

        private void ActivateDamage(Collider colliderTarget)
        {
            if(colliderTarget.TryGetComponent(out Player player))
               _damgeSaw.enabled= true;
        }

        private void TurnOffDamage(Collider colliderTarget)
        {
            if (colliderTarget.TryGetComponent(out Player player))
                _damgeSaw.enabled = false;
        }
    }
}