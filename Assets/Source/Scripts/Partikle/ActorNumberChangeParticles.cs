using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.Partikle
{
    public class ActorNumberChangeParticles : MonoBehaviour
    {
        [SerializeField] private PlayerNumber _playerNumber;
        [SerializeField] private ParticleSystem _particleSystemWallDistroi;
        [SerializeField] private ParticleSystem _partikleSistemIncreaseNumber;

        private void OnEnable() => 
            _playerNumber.NumberChanged += UpNumperPlayPartikleSistem;

        private void OnDisable() => 
            _playerNumber.NumberChanged -= UpNumperPlayPartikleSistem;

        public void PlayPartikleDestroyWall()
        {
            _particleSystemWallDistroi.Play();
        }

        public void StopPartikleDestroyWall()
        {
            _particleSystemWallDistroi.Stop();
        }

        public void UpNumperPlayPartikleSistem()
        {
            _partikleSistemIncreaseNumber.Play();
        }
    }
}
