using UnityEditor;
using static UnityEditor.BuildPipeline;

namespace Editor
{
    public static class Builder
    {
        [MenuItem("Build/🕸️Build WebGL")]
        public static void BuildWebGL()
        {
            BuildPlayer(
                new BuildPlayerOptions()
                {
                    target = BuildTarget.WebGL,
                    locationPathName = "artifacts",
                    scenes = new[]
                    {
                        "Assets/Scenes/Initial.unity",
                        "Assets/Scenes/001_Level_1.unity",
                        "Assets/Scenes/002_Level_2.unity",
                        "Assets/Scenes/003_Level_3.unity",
                    }
                });
        }
    }
}