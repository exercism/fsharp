namespace CodeFenceChecker


open System.IO
open MAB.DotIgnore
open Microsoft.Extensions.FileSystemGlobbing
open Microsoft.Extensions.FileSystemGlobbing.Abstractions

module Program =
    [<EntryPoint>]
    let main argv =
        let directory = argv |> Array.tryHead |> Option.defaultWith Directory.GetCurrentDirectory |> DirectoryInfo

        let ignoreList =
            directory.EnumerateFiles(".codefenceignore", SearchOption.TopDirectoryOnly)
            |> Seq.tryHead
            |> Option.map (fun fileInfo -> IgnoreList(fileInfo.FullName))
            |> Option.defaultValue (IgnoreList(Seq.empty))
        
        let matcher = Matcher().AddInclude("**/*.md")
        let matches =
            matcher.Execute(DirectoryInfoWrapper(directory)).Files
            |> Seq.map (fun matchedFile -> FileInfo(matchedFile.Path))
            |> Seq.filter (fun matchedFile -> ignoreList.IsIgnored(matchedFile) |> not)
            |> Seq.toList

        printfn "%A" matches

        0