using System;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Vector3 _castCenterOffset;
        [SerializeField] private float _castDistance = 5f;

        private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
        private bool _isOnGround = true;

        public event Action Changed;

        public bool IsOnGround
        {
            get => _isOnGround;
            private set
            {
                if (value == _isOnGround) return;
                _isOnGround = value;
                    
                Changed?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            IsOnGround = Physics.BoxCastNonAlloc(
                transform.position + _castCenterOffset,
                _boxCollider.size * transform.localScale.x / 2, 
                Vector3.down, 
                _raycastHits, 
                Quaternion.identity,
                _castDistance, 
                _layerMask) > 0;
        }
    }
}