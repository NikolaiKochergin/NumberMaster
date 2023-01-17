using Source.Scripts.Infrastructure;
using Source.Scripts.Services.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Plauer
{
    public class PlayerMove : MonoBehaviour
    {
        public float Speed;
        private IInputService _inputService;
        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = new Vector3(Speed * 3, 0, 0) * Time.deltaTime; 
        }
    }
}