using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Wall
{
    [SelectionBase]
    public class DividingWall : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private Player _player;
        private int _playerTriggersCount;
        
        private void Awake()
        {
            _triggerObserver.TriggerEnter += OnTriggerEnter;
            _triggerObserver.TriggerExit += OnTriggerExit;
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
                _playerTriggersCount += 1;
                player.PlayerMove.SetBorder(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                _playerTriggersCount -= 1;

                if (_playerTriggersCount == 0) 
                    player.PlayerMove.UnsetBorder(this);
            }
        }
    }
}
