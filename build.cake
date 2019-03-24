var target = Argument("target", "Default");
var configuration = Argument("target", "Release");

var solutionPath = "./DotnetCoreCake.sln";

Task("Clean")
    .Does(() => {
        DotNetCoreClean(solutionPath);
    });

Task("Restore Nuget Packages")
    .IsDependentOn("Clean")
    .Does(() => {
        NuGetRestore(solutionPath);
    });

Task("Build")
    .IsDependentOn("Restore Nuget Packages")
    .Does(() => {
        DotNetCoreBuild(solutionPath);
    });

Task("Default")
    .IsDependentOn("Build")
    .Does(() => {});

RunTarget(target);
