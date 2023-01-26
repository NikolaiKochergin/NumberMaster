using System;
using Source.Scripts.Logic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerAnimator : MonoBehaviour , IAnimatorStateReader
    {
        [SerializeField] private Animator _animator;

        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int FinishHash = Animator.StringToHash("Finish");
        private static readonly int IncreaseNumberHash = Animator.StringToHash("IncreaseNumber");
        private static readonly int FallHash = Animator.StringToHash("Fall");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _jumpStateHash = Animator.StringToHash("Jump");
        private readonly int _finishStateHash = Animator.StringToHash("Finish");
        private readonly int _increaseNumberStateHash = Animator.StringToHash("IncreaseNumber");
        private readonly int _fallStateHash = Animator.StringToHash("Fall");


        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited; 

        public AnimatorState State { get; private set; }

        public void PlayJump() => 
            _animator.SetTrigger(JumpHash);

        public void PlayFinish() => 
            _animator.SetTrigger(FinishHash);

        public void PlayIncreaseNumber() => 
            _animator.SetTrigger(IncreaseNumberHash);

        public void PlayFall() => 
            _animator.SetTrigger(FallHash);

        public void EnteredState(int stateHash) => 
            StateEntered?.Invoke(StateFor(stateHash));

        public void ExitedState(int stateHash) => 
            StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            
            if (stateHash == _idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == _jumpStateHash)
                state = AnimatorState.Jump;
            else if (stateHash == _finishStateHash)
                state = AnimatorState.Finish;
            else if (stateHash == _increaseNumberStateHash)
                state = AnimatorState.IncreaseNumber;
            else if (stateHash == _fallStateHash)
                state = AnimatorState.Fall;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}