using Source.Scripts.Services.Input;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputService _inputService;
        private IStaticDataService _staticData;
        private float _speed;
        
        public void Construct(IInputService inputService, IStaticDataService staticData)
        {
            _inputService = inputService;
            _staticData = staticData;
        }

        private void Start() => 
            _speed = _staticData.ForPlayerSpeed();

        private void Update() => 
            Move();

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;

        public void SetSpeedFactor(float factor) => 
            _speed = _staticData.ForPlayerSpeed() * factor;

        private void Move()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            transform.position += transform.right * _inputService.DeltaX;
            //transform.position = new Vector3(_inputService.DeltaX, transform.position.y, transform.position.z);
        }
    }
}