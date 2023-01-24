using DG.Tweening;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerFinisherMove : MonoBehaviour
    {
        [SerializeField] private float _positionX;
        [SerializeField] private float _duration;
        [SerializeField] private float _speed;

        private void Awake() => 
            Disable();

        private void OnEnable() => 
            transform.DOMoveX(_positionX, _duration);

        private void Update() => 
            transform.position += transform.forward * _speed * Time.deltaTime;

        public void AddSpeed(float speed) => 
            _speed += speed;

        public void Enable() => 
            enabled = true;

        public void Disable() =>
            enabled = false;
    }
}
