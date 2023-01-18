using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class DamgeSaw : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void Awake()
        {
            enabled = false;
        }

        void Update()
        {
            Debug.Log("Удары!");
        }
    }
}