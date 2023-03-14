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
    Console.WriteLine("Build will be here");
});

RunTarget(target);