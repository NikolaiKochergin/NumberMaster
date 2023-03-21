using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Finisher
{
    [SelectionBase]
    public class FinishPanel : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private int _value;
        [SerializeField] private NumberText _numberText;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private bool _isPlayerFinished;

        public Renderer Renderer => _renderer;
        
        private void Awake() => 
            _numberText.SetText(_value);

        private void OnEnable() => 
            _triggerObserver.TriggerEnter += IsPlayerWeaker;

        private void OnDisable() => 
            _triggerObserver.TriggerEnter -= IsPlayerWeaker;

        public void SetValue(int value)
        {
            _value = value;
            _numberText.SetText(value);
        }

        private void IsPlayerWeaker(Collider collider)
        {
            if(_isPlayerFinished)
                return;
            
            if(collider.attachedRigidbody.TryGetComponent(out Player player))
            {
                if(player.PlayerNumber.Current >= _value)
                {
                    Hide();
                    player.PlayerFinisherMove.AddSpeed(1);
                    player.ActorCameraShake.Shake();
                }
                else
                {
                    player.PlayerFinisherMove.Disable();
                    _isPlayerFinished = true;
                    player.ActorEndLevel.ShowFinishAnimation();
                }
            }
        }

        private void Hide() => 
            transform.position = new Vector3(transform.position.x, -8, transform.position.z);
    }
}
