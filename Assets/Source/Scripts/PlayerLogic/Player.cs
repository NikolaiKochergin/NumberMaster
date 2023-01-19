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
        [SerializeField] private PlayerMoveFinish _playerMoveFinish;
        [SerializeField] private ParticleSystem _particleSystemWallDistroi;

        public PlayerMove PlayerMove => _playerMove;
        public PlayerNumber PlayerNumber => _playerNumber;
        public PlayerMoveFinish PlayerMoveFinish => _playerMoveFinish;
        
        public void LoadProgress(PlayerProgress progress)
        {
            _playerNumber.LoadProgress(progress);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            _playerNumber.UpdateProgress(progress);
        }

        public void PlayPartikleDestroyWall()
        {
            _particleSystemWallDistroi.Play();
        }

        public void StopPartikleDestroyWall()
        {
            _particleSystemWallDistroi.Stop();
        }
    }
}
