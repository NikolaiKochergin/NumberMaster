using Source.Scripts.Infrastructure.States;
using Source.Scripts.Logic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorEndLevel : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;

        private IGameStateMachine _stateMachine;

        public void Construct(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void ShowFinishAnimation()
        {
            _playerAnimator.PlayFinish();
            _playerAnimator.StateExited += OnStateExited;
        }

        private void OnStateExited(AnimatorState state)
        {
            if (state == AnimatorState.Finish)
            {
                _playerAnimator.StateExited -= OnStateExited;
                _stateMachine.Enter<LevelCompleteState>();
            }
        }
    }
}
