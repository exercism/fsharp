// Include Fake library
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.NUnit3

// Directories
let buildDir  = "./build/"
let sourceDir = "./exercises/"

// Files
let solutionFile = buildDir @@ "/exercises.fsproj"
let compiledOutput = buildDir @@ "xfsharp.dll"
let nunitToJunitTransformFile = "./paket-files" @@ "nunit" @@ "nunit-transforms" @@ "nunit3-junit" @@ "nunit3-junit.xslt"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "Copy" (fun _ -> CopyDir buildDir sourceDir allFiles)

Target "BuildUnchanged" (fun _ ->
    MSBuildRelease buildDir "Build" [solutionFile]
    |> Log "Build unchanged: "
)

Target "PrepareTests" (fun _ ->
    let ignorePattern = "(\[<Ignore\(\"Remove to run test\"\)>\]|, Ignore = \"Remove to run test case\")"

    !! (buildDir @@ "**/*Test.fs")
    |> RegexReplaceInFilesWithEncoding ignorePattern "" System.Text.Encoding.UTF8
)

Target "BuildWithAllTests" (fun _ ->
    MSBuildRelease buildDir "Rebuild" [solutionFile]
    |> Log "Build with tests: "
)

Target "Test" (fun _ ->
    if getEnvironmentVarAsBool "APPVEYOR" then
        [compiledOutput]
        |> NUnit3 (fun p -> { p with 
                                ShadowCopy = false
                                ToolPath = "nunit3-console.exe" })
    else if getEnvironmentVarAsBool "CIRCLECI" then
        [compiledOutput]
        |> NUnit3 (fun p -> { p with 
                                ShadowCopy = false
                                ResultSpecs = [sprintf "junit-results.xml;transform=%s" nunitToJunitTransformFile] })
    else
        [compiledOutput]
        |> NUnit3 (fun p -> { p with ShadowCopy = false })
)

// Build order
"Clean" 
  ==> "Copy"
  ==> "BuildUnchanged"
  ==> "PrepareTests"
  ==> "BuildWithAllTests"    
  ==> "Test"

// Start build
RunTargetOrDefault "Test"