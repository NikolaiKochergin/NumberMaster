using Source.Scripts.InteractiveObjects.Number;
using UnityEngine;
using Source.Scripts.PlayerLogic;

namespace Source.Scripts.InteractiveObjects.Wall
{
    public class InteractiveWall : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private InteractiveNumberView _interactiveNumberView;
        [SerializeField] private DamageWall _damageWal;
        [SerializeField] private int _value;
        [SerializeField] private float _slowDownFactor = 0.3f;

        private void Awake()
        {
            _interactiveNumberView.SetValue(_value);
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
            _interactiveNumberView.SetValue(_value);
        }

        private void AffectPlayer(Collider other)
        {
            if (!other.TryGetComponent(out Player player)) return;
            if (player.PlayerNumber.Current >= _value)
            {
                player.PlayerMove.SetSpeedFactor(_slowDownFactor);
                _damageWal.enabled = true;
                _damageWal.SetHealth(player, this);
                player.ActorPlayerPartikle.PlayPartikleDestroyWall();
            }
            else
            {
                Debug.Log("Player Die");
            }
        }

        private void AffectPlayerOff(Collider collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                _damageWal.enabled = false;
                player.PlayerMove.SetSpeedFactor(1f);
                player.ActorPlayerPartikle.StopPartikleDestroyWall();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}