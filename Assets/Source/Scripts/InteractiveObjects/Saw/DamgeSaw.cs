using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class DamgeSaw : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _dely;

        private PlayerNumber _playerNumber;
        private float _elepsedTime = 0;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            _elepsedTime+= Time.deltaTime;

            if (_elepsedTime >= _dely)
            {
                _playerNumber.TakeNumber(-_damage);
                _elepsedTime=0;
                Debug.Log("Удары!");
            }
        }

        public void SetHealth(PlayerNumber playerNumber)
        {
            _playerNumber = playerNumber;
        }
    }
}