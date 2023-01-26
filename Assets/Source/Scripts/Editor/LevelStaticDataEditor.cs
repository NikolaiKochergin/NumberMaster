using System.Linq;
using Source.Scripts.Logic;
using Source.Scripts.Logic.EnemyNumbersSpawners;
using Source.Scripts.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                levelData.EnemyNumbers = FindObjectsOfType<SpawnMarker>()
                    .Select(x => new EnemyNumbersStaticData(x.GetComponent<UniqueId>().Id, x.NumberValue, x.transform.position, x.transform.rotation))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}