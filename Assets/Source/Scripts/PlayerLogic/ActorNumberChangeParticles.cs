using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorNumberChangeParticles : MonoBehaviour
    {
        [SerializeField] private PlayerNumber _playerNumber;
        [SerializeField] private ParticleSystem _reductionNumberParticles;
        [SerializeField] private ParticleSystem _increaseNumberParticles;

        private int _oldNumber;

        private void Start()
        {
            _oldNumber = _playerNumber.Current;
            _playerNumber.NumberChanged += OnNumberChanged;
        }

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= OnNumberChanged;
        }

        private void OnNumberChanged()
        {
            if (_oldNumber < _playerNumber.Current)
                _increaseNumberParticles.Play();
            else
                _reductionNumberParticles.Emit(14);

            _oldNumber = _playerNumber.Current;
        }
    }
}
