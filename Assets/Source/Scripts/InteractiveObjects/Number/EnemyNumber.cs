using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
    public class EnemyNumber : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;
        [SerializeField] private EnemyNumberView _enemyNumberView;

        private int _value;
        private bool _isTaken;

        private void Awake() => 
            _trigger.TriggerEnter += AffectPlayer;

        private void OnDestroy()
        {
            if (_trigger != null)
                _trigger.TriggerEnter -= AffectPlayer;
        }

        public void Construct(PlayerNumber playerNumber) =>
            _enemyNumberView.Construct(playerNumber);

        public void Initialize(int value)
        {
            _value = value;
            _enemyNumberView.Initialize(value);
        }

        private void AffectPlayer(Collider other)
        {
            if(_isTaken)
                return;
            
            if (other.attachedRigidbody.TryGetComponent(out PlayerNumber playerNumber))
            {
                _isTaken = true;
                _trigger.gameObject.SetActive(false);
                
                playerNumber.TakeNumber(_value);
                if (playerNumber.Current >= _value)
                    Die();
            }
        }

        private void Die() => 
            Destroy(gameObject);
    }
}
