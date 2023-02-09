namespace CodeFenceChecker

open System.IO
open FSharp.Compiler.Diagnostics
open MAB.DotIgnore
open Markdig
open Markdig.Syntax
open Microsoft.Extensions.FileSystemGlobbing
open Microsoft.Extensions.FileSystemGlobbing.Abstractions

type CodeBlock = CodeBlock of code: string 
type ParsedMarkdownFile = ParsedMarkdownFile of path: string * codeBlocks: CodeBlock list
type InvalidMarkdownFile = InvalidMarkdownFile of path: string * errors: string list

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
            |> Seq.map (fun matchedFile -> matchedFile.Path)
            |> Seq.toList
            
        let parsedMarkdownFiles = [
            for markdownFile in markdownFiles do
                let markdown = Markdown.Parse(File.ReadAllText(Path.Combine(directory.FullName, markdownFile)))            
                let codeBlocks = [ 
                    for fencedCodeBlock in markdown.Descendants<FencedCodeBlock>() do
                        if fencedCodeBlock.Info = "fsharp" then
                            let code = fencedCodeBlock.Lines.Lines |> Seq.map string |> String.concat "\n"
                            if not (code.Contains("compiler error")) then                                
                                yield CodeBlock(code)                            
                    ]
                yield ParsedMarkdownFile(markdownFile, codeBlocks)
        ]

        use fsiSession = FSIWrapper().Session
        
        let invalidMarkdownFiles = [
            for ParsedMarkdownFile(path, codeBlocks) in parsedMarkdownFiles do
                let errors = [
                    for CodeBlock(code) in codeBlocks do                
                        let parseFileResults, _, _ = fsiSession.ParseAndCheckInteraction(code)
                        if parseFileResults.ParseHadErrors then
                            yield! parseFileResults.Diagnostics
                            |> Seq.filter (fun diagnostic -> diagnostic.Severity = FSharpDiagnosticSeverity.Error)
                            |> Seq.map (fun diagnostic -> diagnostic.Message)
                ]

                if not (List.isEmpty errors) then
                    yield InvalidMarkdownFile(path, errors)
        ]
        
        for InvalidMarkdownFile(path, errors) in invalidMarkdownFiles do
            printfn $"Errors in file: %s{path}"
            printfn "%s" (String.concat "\n" errors)
            printfn ""
        
        if List.isEmpty invalidMarkdownFiles then 0 else 1
        