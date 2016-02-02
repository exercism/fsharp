// Include Fake library
#r "tools/FAKE/tools/FakeLib.dll"

open Fake
open Fake.FscHelper
open Fake.Testing.NUnit3

// Properties
let buildDir = getBuildParamOrDefault "buildDir" "./build/"
let sourceDir = "./exercises/"
let testDll = buildDir @@ "Tests.dll"
let nunitFrameworkDll = "tools/NUnit/lib/nunit.framework.dll"

let exampleFiles() = !! (buildDir @@ "./**/Example.fs") |> List.ofSeq
let testFiles() = !! (buildDir @@ "./**/*Test*.fs") |> List.ofSeq
let buildSourceFiles() = exampleFiles() @ testFiles() 
  
// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "CopySource" (fun _ ->
    CopyDir buildDir sourceDir allFiles
)

Target "ModifySource" (fun _ ->
    buildSourceFiles()
    |> ReplaceInFiles [("[<Ignore>]", ""); ("; Ignore", ""); (", Ignore = true", "")]
)

Target "Build" (fun _ ->
  buildSourceFiles()
  |> List.ofSeq
  |> Fsc (fun p ->
           { p with Output = testDll
                    References = [nunitFrameworkDll]
                    FscTarget = Library })
)

Target "Test" (fun _ ->
    Copy buildDir [nunitFrameworkDll]
    
    [testDll]
    |> NUnit3 (fun p -> 
        { p with
            ShadowCopy = false })
)

Target "Default" (fun _ -> ())
  
"Clean"
    ==> "CopySource"
    ==> "ModifySource"    
    ==> "Build"    
    ==> "Test"
    ==> "Default"
  
RunTargetOrDefault "Default"