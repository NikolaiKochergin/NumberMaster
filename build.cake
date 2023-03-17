#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-WebGL");

Task("Clean-Artifacts")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});

Task("Test-WebGL")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(
        2021, 3, 14, 'f', 1,
        new UnityEditorArguments
        {
            ProjectPath = "../NumberMaster",
            BuildTarget = BuildTarget.WebGL,
            LogFile = "./artifacts/unity.log",
            RunTests = true,
            TestPlatform = TestPlatform.StandaloneWindows
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        }
        );
});

Task("Build-WebGL")
    .IsDependentOn("Test-WebGL")
    .Does(() =>
{
    UnityEditor(
        2021, 3, 14, 'f', 1,
        new UnityEditorArguments
        {
            ProjectPath = "../NumberMaster",
            ExecuteMethod = "Editor.Builder.BuildWebGL",
            BuildTarget = BuildTarget.WebGL,
            LogFile = "./artifacts/unity.log",
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        }
        );
});

RunTarget(target);