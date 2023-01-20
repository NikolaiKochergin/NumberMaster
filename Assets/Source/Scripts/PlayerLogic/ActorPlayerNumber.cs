using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorPlayerNumber : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField]private PlayerNumber _playerNumber;

        private void Awake() => 
            _playerNumber.NumberChanged += UpdatePlayerView;

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= UpdatePlayerView;
        }

        private void UpdatePlayerView() => 
            _playerView.ShowValue(_playerNumber.Current);
    }
}