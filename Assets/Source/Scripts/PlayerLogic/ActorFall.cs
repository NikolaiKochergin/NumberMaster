using Source.Scripts.Infrastructure.States;
using Source.Scripts.Logic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorFall : MonoBehaviour
    {
        [SerializeField] private PlayerViewModel _playerViewModel;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerMove _playerMove;

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
            _playerMove.Disable();
            _playerViewModel.FallChecker.Disable();
            _playerAnimator.PlayFall();
            _playerAnimator.StateExited += SetFailState;
        }

        private void SetFailState(AnimatorState state)
        {
            if (state == AnimatorState.Fall)
            {
                _playerAnimator.StateExited -= SetFailState;
                _stateMachine.Enter<FailState>();
            }
        }
    }
}
