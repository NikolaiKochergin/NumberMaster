using Source.Scripts.Infrastructure.States;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorFail : MonoBehaviour
    {
        [SerializeField] private PlayerNumber _playerNumber;
        
        private IGameStateMachine _stateMachine;

        public void Construct(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Awake() => 
            _playerNumber.FailHappened += OnFailHappened;

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.FailHappened -= OnFailHappened;
        }

        private void OnFailHappened() => 
            _stateMachine.Enter<FailState>();
    }
}
