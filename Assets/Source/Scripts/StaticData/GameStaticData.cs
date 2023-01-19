using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Static Data/GameData")]
    public class GameStaticData : ScriptableObject
    {
        [Header("Player Stats")]
        [Min(0)] public float PlayerSpeed = 3;

        [Space] 
        [Header("Input Settings")] 
        [Min(0)]
        public float MouseSensitivity = 0.2f;
        [Min(0)] 
        public float KeyboardSensitivity = 0.03f;

        [Space] 
        [Header("Levels Settings")] 
        [Min(1)] public int RepeatLevelNumber = 1;
        public List<string> LevelSceneNames;
    }
}