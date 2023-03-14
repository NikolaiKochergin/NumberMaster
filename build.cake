#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-WebGL");

Task("Clean-Artifacts")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});

Task("Build-WebGL")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(2021, 3, 14, 'f', 1,
        new UnityEditorArguments
        {
            ProjectPath = "./",
            ExecuteMethod = "Editor.Builder.BuildWebGL",
            BuildTarget = BuildTarget.WebGL,
            LogFile = "./artifacts/unity.log"
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        }
        );
});

RunTarget(target);