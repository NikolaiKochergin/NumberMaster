using UnityEngine;

namespace Source.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "GameData", menuName = "StaticData/GameData")]
    public class GameStaticData : ScriptableObject
    {
        [Header("Player Stats")]
        [Min(0)] public float PlayerSpeed;
    }
}