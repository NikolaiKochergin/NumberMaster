using Source.Scripts.Services.Input;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputService _inputService;
        private float _speed;

        public float Speed => _speed;
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Initialize(float speed) => 
            _speed = speed;

        private void Update() => 
            Move();

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;

        public void SetSpeed(float speed)
        {
            _speed= speed;
        }

        private void Move()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            transform.position = new Vector3(_inputService.OffsetX, transform.position.y, transform.position.z);
        }
    }
}