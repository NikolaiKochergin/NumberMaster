using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorPlayerNumber : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        private PlayerNumber _playerNumber;

        private void Awake()
        {
            Construct(GetComponent<PlayerNumber>());
        }

        public void Construct(PlayerNumber playerNumber)
        {
            _playerNumber = playerNumber;
            _playerNumber.NumberChanged += UpdatePlayerView;
        }

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= UpdatePlayerView;
        }

        private void UpdatePlayerView() => 
            _playerView.SetValue(_playerNumber.Current);
    }
}