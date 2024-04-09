#addin nuget:?package=Cake.DocFx&version=1.0.0

var defaultName = "Default";
var restoreName = "Restore";
var styleAnalyzerName = "StyleAnalyzer";
var buildName = "Build";
var staticAnalyzerName = "StaticAnalyzer";
var documentationName = "Documentation";
var testName = "Test";
var cleanName = "Clean";

var target = Argument("target", defaultName);
var configuration = Argument("configuration", "Release");
var solutionPath = "./cs509_hands_on_12.sln";
var outputPath = "./output";
var projectPath = "./CS509HandsOn12/CS509HandsOn12.csproj";
var testProjectPath = "./CS509HandsOn12.Test/CS509HandsOn12.Test.csproj";


Task(restoreName).Does(() => { DotNetRestore(solutionPath); });

Task(buildName).Does(() =>
{
	DotNetBuild(solutionPath, new DotNetBuildSettings
	{
		NoRestore = true,
		Configuration = configuration,
		OutputDirectory = outputPath
	});
});


Task(staticAnalyzerName).IsDependentOn(buildName)
.Does(() =>
{
	DotNetFormatAnalyzers(solutionPath);
});

Task(documentationName).IsDependentOn(staticAnalyzerName)
.Does(() =>
{
	DocFxBuild("./docfx.json");
});

Task(testName).IsDependentOn(documentationName).Does(() =>
{
	DotNetTest(testProjectPath);
});

Task(cleanName).IsDependentOn(testName).Does(() =>
{
	CleanDirectory(outputPath);
});

Task(defaultName).IsDependentOn(cleanName);

RunTarget(target);
