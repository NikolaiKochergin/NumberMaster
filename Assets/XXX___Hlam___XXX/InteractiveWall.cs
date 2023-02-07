using UnityEngine;
using Source.Scripts.PlayerLogic;

namespace Source.Scripts.InteractiveObjects.Wall
{
    public class InteractiveWall : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private NumberText _numberText;
        [SerializeField] private DamageWall _damageWall;
        [SerializeField] private int _value;
        [SerializeField] private float _slowDownFactor = 0.3f;

        private void Awake()
        {
            _numberText.SetText(_value);
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += AffectPlayer;
            _triggerObserver.TriggerExit += AffectPlayerOff;
        }

        private void OnDestroy() =>
            _triggerObserver.TriggerEnter -= AffectPlayer;

        public void TakeDamage(int damage)
        {
            _value -= damage;
            if (_value < 0)
                _value = 0;
            Show();
        }

        private void Show()
        {
            _numberText.SetText(_value);
        }

        private void AffectPlayer(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                player.PlayerMove.SetSpeedFactor(_slowDownFactor);
                _damageWall.enabled = true;
                _damageWall.SetHealth(player, this);
            }
        }

        private void AffectPlayerOff(Collider collider)
        {
            if (collider.attachedRigidbody.TryGetComponent(out Player player))
            {
                _damageWall.enabled = false;
                player.PlayerMove.SetSpeedFactor(1f);
            }
        }
    }
}