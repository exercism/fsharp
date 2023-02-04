namespace CodeFenceChecker

[<AutoOpen>]
module Collector =
    open System
    open System.IO
    open System.Text.RegularExpressions

    let nl = Environment.NewLine
    let sep = Path.DirectorySeparatorChar
    let isEmptyLine (line: string) = String.IsNullOrEmpty(line.Trim())

    let private matchBlockStart (line: string) = Regex.IsMatch(line, @"^.*[`~]{3,}(fsharp)")
    let private matchBlockEnd (line: string) = Regex.IsMatch(line, @"^.*[`~]{3,}$")

    let collectLines (dir: string) (ignored: string []) =
        let root = Path.Combine(__SOURCE_DIRECTORY__, $"..{sep}..")

        let lines =
            Directory.GetFiles(Path.Combine(root, dir), "*.md", SearchOption.AllDirectories)
            |> Array.filter
                (fun doc ->
                    let docPath = Path.GetRelativePath(root, doc)
                    // drop this document if it matches any of the excluded paths
                    Array.forall
                        (not << (fun (path: string) -> Path.GetDirectoryName(docPath).StartsWith(path)))
                        ignored)
            |> Array.collect
                (fun doc ->
                    File.ReadAllLines(doc)
                    |> Array.filter (not << isEmptyLine)
                    |> Array.map (fun ln -> (ln, Path.GetFullPath(doc))))

        let codeBlocks =
            lines
            |> Array.mapi
                (fun idx (ln, doc) ->
                    if matchBlockStart ln then
                        let code =
                            Array.tryItem (idx + 1) lines
                            |> function
                            | Some _ ->
                                lines.[(idx + 1)..]
                                |> Array.map fst
                                |> Array.takeWhile (not << matchBlockEnd)
                                |> String.concat nl
                            | None -> ""

                        (code, doc)
                    else
                        ("", doc))

        codeBlocks
