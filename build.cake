using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var target = Argument("target", "Default");

var sourceDir = "./exercises";
var buildDir  = "./build";

var defaultSolutionPath     = buildDir + "/Exercises.Default.sln";
var refactoringSolutionPath = buildDir + "/Exercises.Refactoring.sln";

var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = System.Environment.ProcessorCount };

Task("Clean")
    .Does(() => {
		CleanDirectory(buildDir);   
    });

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("Clean")
    .Does(() => {
        CopyDirectory(sourceDir, buildDir);
    });

Task("EnableAllTests")
    .IsDependentOn("CopyExercises")
    .Does(() => {
        var skipRegex = new Regex(@"\[<Ignore\(""Remove to run test""\)>\]", RegexOptions.Compiled);
        var testFiles = GetFiles(buildDir + "/*/*Test.fs");

        foreach (var testFile in testFiles) {
            var contents = System.IO.File.ReadAllText(testFile.FullPath);

            if (skipRegex.IsMatch(contents)) {
                var updatedContents = skipRegex.Replace(contents, "");
                System.IO.File.WriteAllText(testFile.FullPath, updatedContents);
            }
        }
    });

Task("TestRefactoringProjects")
    .IsDependentOn("EnableAllTests")
    .Does(() => {
        var refactoringSolution = ParseSolution(refactoringSolutionPath);
        Parallel.ForEach(refactoringSolution.Projects, parallelOptions, (project) => DotNetCoreTest(project.Path.FullPath));
});

Task("ReplaceStubWithExample")
    .IsDependentOn("TestRefactoringProjects")
    .Does(() => {
        var defaultSolution = ParseSolution(defaultSolutionPath);

        foreach (var project in defaultSolution.Projects) {
            var projectDir = project.Path.GetDirectory();
            var projectName = project.Path.GetFilenameWithoutExtension();
            var stub = projectDir.GetFilePath(projectName).AppendExtension("fs");
            var example = projectDir.GetFilePath("Example.fs");
            
            DeleteFile(stub);
            MoveFile(example, stub);
        }
    });

Task("AddPackagesUsedInExampleImplementations")
    .IsDependentOn("ReplaceStubWithExample")
    .Does(() => {
        // These projects have a working default implementation, and have
        // all the tests enabled. These should pass without any changes.
        var fparsecProjects = 
              GetFiles(buildDir + "/*/Alphametics.fsproj")
            + GetFiles(buildDir + "/*/SgfParsing.fsproj");

    foreach (var fparsecProject in fparsecProjects) {
        DotNetCoreTool(fparsecProject, "add", "package FParsec");
    }
});

Task("TestUsingExampleImplementation")
    .IsDependentOn("AddPackagesUsedInExampleImplementations")
    .Does(() => {
        var defaultSolution = ParseSolution(defaultSolutionPath);
        Parallel.ForEach(defaultSolution.Projects, parallelOptions, (project) => DotNetCoreTest(project.Path.FullPath));
    });

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);