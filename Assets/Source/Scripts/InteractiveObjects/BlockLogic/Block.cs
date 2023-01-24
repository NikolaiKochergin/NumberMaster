using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.BlockLogic
{
    [SelectionBase]
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockViewModel _blockViewModel;
        [SerializeField] private TriggerObserver _trigger;
        [SerializeField] [Min(0)] private int _durability;

        private Player _player;
        private float _accumulatedDistance;
        

        private void Awake()
        {
            _trigger.TriggerEnter += OnTriggerEnter;
            _trigger.TriggerExit += OnTriggerExit;
            enabled = false;
        }

        private void FixedUpdate()
        {
            _accumulatedDistance += _player.PlayerMove.Speed * Time.deltaTime;
            if (_accumulatedDistance > _blockViewModel.WidthPerValue)
            {
                int damage = Mathf.FloorToInt(_accumulatedDistance/_blockViewModel.WidthPerValue);
                _accumulatedDistance %= _blockViewModel.WidthPerValue;

                if (_durability > damage)
                {
                    _durability -= damage;
                    _blockViewModel.SetViewBy(_durability);
                    _player.PlayerNumber.TakeNumber(-damage);
                }
                else
                {
                    _player.PlayerNumber.TakeNumber(-_durability);
                    _player.PlayerMove.SetSpeedFactor(1f);
                    Destroy(gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            if (_trigger != null)
            {
                _trigger.TriggerEnter -= OnTriggerEnter;
                _trigger.TriggerExit -= OnTriggerExit;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                _player = player;
                _player.PlayerMove.SetSpeedFactor(0.3f);
                enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                _player.PlayerMove.SetSpeedFactor(1f);
                enabled = false;
            }
        }


#if  UNITY_EDITOR
        private void OnValidate()
        {
            _blockViewModel.SetViewBy(_durability);
            _trigger.transform.localScale = new Vector3(
                _trigger.transform.localScale.x,
                transform.transform.localScale.y,
                _durability * _blockViewModel.WidthPerValue);
        }
#endif
    }
}