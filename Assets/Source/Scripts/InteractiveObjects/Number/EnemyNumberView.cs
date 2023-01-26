using Source.Scripts.PlayerLogic;
using TMPro;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
    public class EnemyNumberView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _redMaterial;
        [SerializeField] private Material _blueMaterial;
        
        private PlayerNumber _playerNumber;
        private int _value;
        private bool _isRed = true;

        public void Construct(PlayerNumber playerNumber) => 
            _playerNumber = playerNumber;

        public void Initialize(int value)
        {
            SetValue(value);
            _playerNumber.NumberChanged += SetView;
        }

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= SetView;
        }

        private void SetValue(int value)
        {
            _value = value;
            _text.text = _value.ToString();
        }

        private void SetView()
        {
            if (_playerNumber.Current < _value)
            {
                if (_isRed) 
                    return;
                _meshRenderer.material = _redMaterial;
                _isRed = true;
            }
            else
            {
                if (!_isRed) 
                    return;
                _meshRenderer.material = _blueMaterial;
                _isRed = false;
            }
        }
    }
}
