using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var target = Argument("target", "Default");
var exercise = Argument<string>("exercise", null);

var sourceDir = "./exercises";
var buildDir  = "./build";

var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = System.Environment.ProcessorCount };

Task("Clean")
    .Does(() => {
		CleanDirectory(buildDir);   
    }); 

Task("BuildGenerators")
    .IsDependentOn("Clean")
    .Does(() => {
       DotNetCoreBuild("./generators/Generators.fsproj");
    });

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("BuildGenerators")
    .Does(() => {
        CopyDirectory($"{sourceDir}/{exercise}", $"{buildDir}/{exercise}");
    });

Task("EnableAllTests")
    .IsDependentOn("CopyExercises")
    .Does(() => {
        var skipRegex = new Regex(@"Skip = ""Remove to run test""", RegexOptions.Compiled);
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
        var refactoringProjects = 
              GetFiles(buildDir + "/*/TreeBuilding.fsproj")
            + GetFiles(buildDir + "/*/Ledger.fsproj")
            + GetFiles(buildDir + "/*/Markdown.fsproj");

        Parallel.ForEach(refactoringProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath));
});

Task("ReplaceStubWithExample")
    .IsDependentOn("TestRefactoringProjects")
    .Does(() => {
        var projects = GetFiles(buildDir + "/*/*.fsproj");

        foreach (var project in projects) {
            var projectDir = project.GetDirectory();
            var projectName = project.GetFilenameWithoutExtension();
            var stub = projectDir.GetFilePath(projectName).AppendExtension("fs");
            var example = projectDir.GetFilePath("Example.fs");
            
            DeleteFile(stub);
            MoveFile(example, stub);
        }
    });

Task("AddPackagesUsedInExampleImplementations")
    .IsDependentOn("ReplaceStubWithExample")
    .Does(() => {
        var projects = GetFiles(buildDir + "/*/SgfParsing.fsproj");
        Parallel.ForEach(projects, parallelOptions, (project) => DotNetCoreTool(project.FullPath, "add", "package FParsec"));
    });

Task("TestUsingExampleImplementation")
    .IsDependentOn("AddPackagesUsedInExampleImplementations")
    .Does(() => {
        if (string.IsNullOrEmpty(exercise)) {
            DotNetCoreTest($"{buildDir}/Exercises.sln");
        }
        else {
            DotNetCoreTest($"{buildDir}/{exercise}/{exercise}.fsproj");
        }
    });

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);
