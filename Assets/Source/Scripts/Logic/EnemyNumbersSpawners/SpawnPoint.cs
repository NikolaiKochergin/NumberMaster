using Source.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Source.Scripts.Logic.EnemyNumbersSpawners
{
    public class SpawnPoint : MonoBehaviour
    {
        private int _numberValue;

        private IGameFactory _factory;

        public void Construct(IGameFactory gameFactory) =>
            _factory = gameFactory;

        public void Initialize(int numberValue)
        {
            _numberValue = numberValue;
            Spawn();
        }

        private void Spawn()
        {
        }
    }
}