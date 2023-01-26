using UnityEngine;

namespace Source.Scripts.Logic.EnemyNumbersSpawners
{
    public class SpawnMarker : MonoBehaviour
    {
        [SerializeField] private int _numberValue;

        public int NumberValue => _numberValue;
    }
}