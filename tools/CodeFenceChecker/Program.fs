namespace CodeFenceChecker

open System.IO
open MAB.DotIgnore
open Markdig
open Markdig.Syntax
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
        
        let markdownFiles =
            Matcher().AddInclude("**/*.md").Execute(DirectoryInfoWrapper(directory)).Files
            |> Seq.filter (fun matchedFile -> not (ignoreList.IsIgnored(matchedFile.Path, pathIsDirectory = false)))
            |> Seq.toList

        for markdownFile in markdownFiles do        
            let markdown = Markdown.Parse(File.ReadAllText(Path.Combine(directory.FullName, markdownFile.Path)))            
            let fencedCodeBlocks = markdown.Descendants<FencedCodeBlock>()
            for fencedCodeBlock in fencedCodeBlocks do
                if fencedCodeBlock.Info = "fsharp" then
                    // fencedCodeBlock.Lines
                    printfn "%A" fencedCodeBlock

        0