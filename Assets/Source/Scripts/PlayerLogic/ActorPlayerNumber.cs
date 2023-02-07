using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorPlayerNumber : MonoBehaviour
    {
        [SerializeField] private PlayerViewModel _playerViewModel;
        [SerializeField]private PlayerNumber _playerNumber;

        private void Awake() => 
            _playerNumber.NumberChanged += UpdatePlayerView;

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= UpdatePlayerView;
        }

        private void UpdatePlayerView() => 
            _playerViewModel.ShowValue(_playerNumber.Current);
    }
}