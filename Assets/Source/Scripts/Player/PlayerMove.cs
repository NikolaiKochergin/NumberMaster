using Source.Scripts.Infrastructure;
using Source.Scripts.Services;
using Source.Scripts.Services.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Plauer
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _offset;
        [SerializeField] private Camera _camera;
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
            float positionX = _inputService.OffsetX;
            transform.position += new Vector3(0, 0, Speed * 1) * Time.deltaTime;
            transform.position = new Vector3(positionX * _offset, transform.position.y, transform.position.z);
        }
    }
}