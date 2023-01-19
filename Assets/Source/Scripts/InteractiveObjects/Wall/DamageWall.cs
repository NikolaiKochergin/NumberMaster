using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Wall
{
    public class DamageWall : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delay = 0.1f;
        [SerializeField] private float _scaleZ;

        private InteractiveWall _interactiveWall;
        private Player _player;
        private float _elapsedTime = 0;
        private bool _isHit = false;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _delay)
            {

                _isHit = true;

                if (transform.localScale.z > 0 && _isHit)
                {
                    _player.PlayerNumber.TakeNumber(-_damage);
                    _interactiveWall.TakeDamage(_damage);
                    transform.localScale -= new Vector3(0, 0f, _scaleZ);
                    _isHit = false;
                }
                if(transform.lossyScale.z <= 0 && _isHit)
                {
                    transform.localScale = Vector3.zero;
                }

                _elapsedTime = 0;
                Debug.Log("Удары!");
            }
        }

        public void SetHealth(Player player, InteractiveWall interactiveWall)
        {
            _player = player;
            _interactiveWall = interactiveWall;
        }
    }
}
