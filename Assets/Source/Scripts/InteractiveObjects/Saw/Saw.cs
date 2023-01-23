using Source.Scripts.PlayerLogic;
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
            if(colliderTarget.attachedRigidbody.TryGetComponent(out Player player))
            {
               _damgeSaw.enabled= true;
               _damgeSaw.SetHealth(player.PlayerNumber);
            }
        }

        private void TurnOffDamage(Collider colliderTarget)
        {
            if (colliderTarget.attachedRigidbody.TryGetComponent(out Player player)) 
                _damgeSaw.enabled = false;
        }
    }
}