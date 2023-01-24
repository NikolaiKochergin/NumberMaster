using Source.Scripts.Infrastructure.States;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorFall : MonoBehaviour
    {
        [SerializeField] private PlayerViewModel _playerViewModel;

        private IGameStateMachine _stateMachine;

        public void Construct(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Awake() => 
            _playerViewModel.FallChecker.FallHappened += OnFallHappened;

        private void OnDestroy()
        {
            if (_playerViewModel != null)
                _playerViewModel.FallChecker.FallHappened -= OnFallHappened;
        }

        public void Enable() => 
            _playerViewModel.FallChecker.Enable();

        public void Disable() => 
            _playerViewModel.FallChecker.Disable();

        private void OnFallHappened()
        {
            _playerViewModel.FallChecker.Disable();
            _stateMachine.Enter<FailState>();
        }
    }
}
