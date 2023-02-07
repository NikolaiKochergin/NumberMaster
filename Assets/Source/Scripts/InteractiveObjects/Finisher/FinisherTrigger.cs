using Source.Scripts.Infrastructure.States;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Finisher
{
    public class FinisherTrigger : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _triggerObserver.TriggerEnter += SetLevelCompleteState;
        }

        private void OnDestroy()
        {
            if (_triggerObserver != null)
                _triggerObserver.TriggerEnter -= SetLevelCompleteState;
        }

        private void SetLevelCompleteState(Collider other)
        {
            if(other.TryGetComponent(out Player player))
                _stateMachine.Enter<LevelCompleteState>();
        }
    }
}
