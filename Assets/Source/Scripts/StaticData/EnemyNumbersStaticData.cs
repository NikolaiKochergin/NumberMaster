using System;
using UnityEngine;

namespace Source.Scripts.StaticData
{
    [Serializable]
    public class EnemyNumbersStaticData
    {
        public string Id;
        public int NumberValue;
        public Vector3 Position;
        public Quaternion Rotation;

        public EnemyNumbersStaticData(string id, int numberValue, Vector3 position, Quaternion rotation)
        {
            Id = id;
            NumberValue = numberValue;
            Position = position;
            Rotation = rotation;
        }
    }
}