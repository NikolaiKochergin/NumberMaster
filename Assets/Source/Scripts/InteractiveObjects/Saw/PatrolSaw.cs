using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class PatrolSaw : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private SawDamage _sawDamage;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnTriggerEnter;
            _triggerObserver.TriggerExit += OnTriggerExit;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnTriggerEnter;
            _triggerObserver.TriggerExit -= OnTriggerExit;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
                _sawDamage.StartDamage(player);
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.attachedRigidbody.TryGetComponent(out Player player))
                _sawDamage.StopDamage();
        }
    }
}
