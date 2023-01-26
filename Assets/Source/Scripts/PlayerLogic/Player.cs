using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    [SelectionBase]
    public class Player : MonoBehaviour , ISavedProgress
    {
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private PlayerNumber _playerNumber;
        [SerializeField] private PlayerFinisherMove _playerFinisherMove;
        [SerializeField] private ActorFail _actorFail;
        [SerializeField] private ActorFall _actorFall;
        [SerializeField] private ActorCameraShake _actorCameraShake;
        [SerializeField] private ActorEndLevel _actorEndLevel;

        public PlayerMove PlayerMove => _playerMove;
        public PlayerNumber PlayerNumber => _playerNumber;
        public PlayerFinisherMove PlayerFinisherMove => _playerFinisherMove;
        public ActorFail ActorFail => _actorFail;
        public ActorFall ActorFall => _actorFall;
        public ActorCameraShake ActorCameraShake => _actorCameraShake;
        public ActorEndLevel ActorEndLevel => _actorEndLevel;

        public void LoadProgress(PlayerProgress progress) => 
            _playerNumber.LoadProgress(progress);

        public void UpdateProgress(PlayerProgress progress) => 
            _playerNumber.UpdateProgress(progress);
    }
}
