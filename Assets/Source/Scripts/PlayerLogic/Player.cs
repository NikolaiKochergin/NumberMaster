using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class Player : MonoBehaviour , ISavedProgress
    {
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private PlayerNumber _playerNumber;

        public PlayerMove PlayerMove => _playerMove;
        public PlayerNumber PlayerNumber => _playerNumber;
        
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
