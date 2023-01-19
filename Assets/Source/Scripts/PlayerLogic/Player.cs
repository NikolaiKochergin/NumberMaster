using Source.Scripts.Data;
using Source.Scripts.Partikle;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Scripts.PlayerLogic
{
    [SelectionBase]
    public class Player : MonoBehaviour , ISavedProgress
    {
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private PlayerNumber _playerNumber;
        [SerializeField] private PlayerFinisherMove _playerFinisherMove;
        [FormerlySerializedAs("_actorNamberChangeParticles")] [FormerlySerializedAs("_actorPlayerPartikle")] [SerializeField] private ActorNumberChangeParticles _actorNumberChangeParticles;

        public PlayerMove PlayerMove => _playerMove;
        public PlayerNumber PlayerNumber => _playerNumber;
        public PlayerFinisherMove PlayerFinisherMove => _playerFinisherMove;
        public ActorNumberChangeParticles ActorNumberChangeParticles => _actorNumberChangeParticles;

        public void LoadProgress(PlayerProgress progress)
        {
            _playerNumber.LoadProgress(progress);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            _playerNumber.UpdateProgress(progress);
        }
    }
}
