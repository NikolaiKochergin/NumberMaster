using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class SawDamage : MonoBehaviour
    {
    
        [SerializeField] [Min(0)] private int _damage = 1;
        [SerializeField] [Min(0)] private float _damagePeriod = 0.5f;

        private Player _player;
        private float _timer;

        private void Awake() => 
            enabled = false;

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                ApplyDamage();
                _timer = _damagePeriod;
            }
        }

        public void StartDamage(Player player)
        {
            _player = player;
            enabled = true;
        }

        public void StopDamage() => 
            enabled = false;

        private void ApplyDamage() => 
            _player.PlayerNumber.TakeNumber(-_damage);
    }
}
