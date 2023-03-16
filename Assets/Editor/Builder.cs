using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using static UnityEditor.BuildPipeline;

namespace Editor
{
    public static class Builder
    {
        [MenuItem("Build/🕸️Build WebGL")]
        public static void BuildWebGL()
        {
            BuildReport report = BuildPlayer(
                new BuildPlayerOptions()
                {
                    target = BuildTarget.WebGL,
                    locationPathName = "artifacts",
                    scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray(),
                });

            if (report.summary.result != BuildResult.Succeeded)
                throw new Exception("Failed to build WebGL package. See log for details.");
        }
    }
}