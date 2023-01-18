using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
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
            if (other.TryGetComponent(out PlayerNumber playerNumber))
            {
                playerNumber.TakeNumber(_value);
                Destroy(gameObject);
            }
        }
    }
}
