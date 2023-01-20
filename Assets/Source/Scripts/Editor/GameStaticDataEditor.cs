using System.IO;
using Source.Scripts.StaticData;
using UnityEditor;
using UnityEngine;

namespace Source.Scripts.Editor
{
    [CustomEditor(typeof(GameStaticData))]
    public class GameStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameStaticData gameData = (GameStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                gameData.LevelSceneNames.Clear();
                
                EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

                foreach (EditorBuildSettingsScene scene in scenes)
                    gameData.LevelSceneNames.Add(Path.GetFileNameWithoutExtension(scene.path));
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}