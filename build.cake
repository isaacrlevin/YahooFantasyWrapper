#tool "nuget:?package=GitReleaseNotes"
#tool "nuget:?package=GitVersion.CommandLine"

var target = Argument("target", "Default");
var wrapperProject = "./src/YahooFantasyWrapper/YahooFantasyWrapper.csproj";

var outputDir = "./artifacts/";

Task("Clean")
    .Does(() => {
        if (DirectoryExists(outputDir))
        {
            DeleteDirectory(outputDir, recursive:true);
        }
    });

Task("Restore")
    .Does(() => {
        DotNetCoreRestore("src");
    });

GitVersion versionInfo = null;
Task("Version")
    .Does(() => {
        GitVersion(new GitVersionSettings{
            UpdateAssemblyInfo = true,
            OutputType = GitVersionOutput.BuildServer
        });
        versionInfo = GitVersion(new GitVersionSettings{ OutputType = GitVersionOutput.Json });
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() => {
        MSBuild("./src/YahooFantasyWrapper/YahooFantasyWrapper.csproj");
    });

Task("Package")
    .IsDependentOn("Build")
    .Does(() => {
        var settings = new DotNetCorePackSettings
        {
            ArgumentCustomization = args=> args.Append(" --include-symbols /p:PackageVersion=" + versionInfo.NuGetVersion),
            OutputDirectory = outputDir,
            NoBuild = true
        };

        DotNetCorePack(wrapperProject, settings);

        System.IO.File.WriteAllLines(outputDir + "artifacts", new[]{
            "nuget:YahooFantasyWrapper." + versionInfo.NuGetVersion + ".nupkg",
            "nugetSymbols:YahooFantasyWrapper." + versionInfo.NuGetVersion + ".symbols.nupkg",
            "releaseNotes:releasenotes.md"
        });

        // if (AppVeyor.IsRunningOnAppVeyor)
        // {
        //     foreach (var file in GetFiles(outputDir + "**/*"))
        //         AppVeyor.UploadArtifact(file.FullPath);
        // }
    });

Task("Default")
    .IsDependentOn("Package");

RunTarget(target);