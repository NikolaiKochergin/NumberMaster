using System.Collections;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services;
using TMPro;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
    public class InteractiveNumberView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _redMaterial;
        [SerializeField] private Material _blueMaterial;

        private PlayerNumber _playerNumber;
        private int _value;
        private bool _isRed = true;

        private IEnumerator Start()
        {
            yield return AllServices.Container.Single<IGameFactory>();
            yield return AllServices.Container.Single<IGameFactory>().Player;
            _playerNumber = AllServices.Container.Single<IGameFactory>().Player.PlayerNumber;
            SetView();
            _playerNumber.NumberChanged += SetView;
        }

        private void OnDestroy()
        {
            if (_playerNumber != null)
                _playerNumber.NumberChanged -= SetView;
        }

        public void SetValue(int value)
        {
            _value = value;
            _text.text = value.ToString();
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
