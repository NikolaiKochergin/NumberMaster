using Source.Scripts.InteractiveObjects.Wall;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputService _inputService;
        private IStaticDataService _staticData;
        private DividingWall _leftBorder;
        private DividingWall _rightBorder;

        public float Speed { get; private set; }

        public void Construct(IInputService inputService, IStaticDataService staticData)
        {
            _inputService = inputService;
            _staticData = staticData;
        }

        private void Start() => 
            Speed = _staticData.ForPlayerSpeed();

        private void Update() => 
            Move();

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;

        public void SetSpeedFactor(float factor) => 
            Speed = _staticData.ForPlayerSpeed() * factor;

        public void SetBorder(DividingWall dividingWall)
        {
            Vector3 offset = transform.position - dividingWall.transform.position;
            Vector3 relativeOffset = transform.worldToLocalMatrix * offset;

            if (relativeOffset.x > 0)
                _leftBorder = dividingWall;
            else
                _rightBorder = dividingWall;
        }

        public void UnsetBorder(DividingWall dividingWall)
        {
            if (Equals(_leftBorder, dividingWall))
                _leftBorder = null;
            else if (Equals(_rightBorder, dividingWall))
                _rightBorder = null;
        }

        private void Move()
        {
            float positionZ = transform.position.z + Speed * Time.deltaTime;
            float offsetX = 0;
            float leftInputLimit = float.MinValue;
            float rightInputLimit = float.MaxValue;

            if (_leftBorder)
            {
                leftInputLimit = 0;
                offsetX += Speed * Time.deltaTime;
            }

            if (_rightBorder)
            {
                rightInputLimit = 0;  
                offsetX -= Speed * Time.deltaTime;
            }

            offsetX += Mathf.Clamp(_inputService.DeltaX, leftInputLimit, rightInputLimit);

            transform.position = new Vector3(transform.position.x + offsetX, transform.position.y, positionZ);
        }
    }
}