using Source.Scripts.CameraLogic;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Finisher
{
    [SelectionBase]
    public class FinishPanel : MonoBehaviour
    {
        [SerializeField] private int _value;
        [SerializeField] private NumberText _numberText;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private ShakeCamera _shakeCamera;

        private IGameStateMachine _stateMachine;

        private bool _isPlayerFinished;
        
        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _numberText.SetText(_value);
        }

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
                    transform.position = new Vector3(transform.position.x,-8,transform.position.z);
                    player.PlayerFinisherMove.AddSpeed(1);
                    _shakeCamera.PlayCameraShake();
                }
                else
                {
                    player.PlayerFinisherMove.Disable();
                    _isPlayerFinished = true;
                    _stateMachine.Enter<LevelCompleteState>();
                }
            }
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            InitCameraShake();
        }

        private void Reset()
        {
            InitCameraShake();
        }

        private void InitCameraShake()
        {
            if(Camera.main.GetComponentInParent<ShakeCamera>())
                _shakeCamera = Camera.main.GetComponentInParent<ShakeCamera>();
        }
#endif
    }
}
