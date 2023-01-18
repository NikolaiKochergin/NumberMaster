using Source.Scripts.Services;
using Source.Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Plauer
{
    public class PlayerMove : MonoBehaviour
    {
        public float Speed;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float positionX = _inputService.PositionX;
            transform.position += new Vector3(0, 0, Speed * 1) * Time.deltaTime;
            transform.position = new Vector3(positionX * Speed, transform.position.y, transform.position.z);
        }
    }
}