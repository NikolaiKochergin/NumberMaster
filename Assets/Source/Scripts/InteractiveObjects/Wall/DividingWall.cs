using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Wall
{
    public class DividingWall : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private float _moveForce;

        private Player _player;
        
        private void Awake()
        {
            _triggerObserver.TriggerEnter += OnTriggerEnter;
            _triggerObserver.TriggerExit += OnTriggerExit;
            enabled = false;
        }

        private void LateUpdate()
        {
            if((transform.position - _player.transform.position).x > 0)
                _player.transform.position += transform.right * _moveForce * Time.deltaTime;
            else
                _player.transform.position -= transform.right * _moveForce * Time.deltaTime;
        }

        private void OnDestroy()
        {
            if (_triggerObserver != null)
            {
                _triggerObserver.TriggerEnter -= OnTriggerEnter;
                _triggerObserver.TriggerExit -= OnTriggerExit;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                _player = player;
                enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                enabled = false;
            }
        }
    }
}
