namespace CodeFenceChecker

open FSharp.Compiler.Diagnostics

[<AutoOpen>]
module Parser =

    let private collectErrors (inErrs: FSharpDiagnostic []) (outErrs: string []) (expr: string) (msg: string) =
        inErrs
        |> Array.filter (fun e -> e.Severity = FSharpDiagnosticSeverity.Error)
        |> Array.fold
            (fun acc e ->
                Array.concat [ acc
                               [| $"{msg}:{nl}{e.Message}{nl}```fsharp{nl}{expr}{nl}```" |] ])
            outErrs

    let parse (codeBlocks: (string * string) []) =
        use fsiSession = FSIWrapper().Session
        let parsed = ResizeArray<string>()

        codeBlocks
        |> Array.fold
            (fun res (expr, doc) ->
                if not <| parsed.Contains(doc) then printfn $"Checking {doc}"
                parsed.Add(doc)

                if (not << isEmptyLine) expr then
                    let parseResults, _, _ = fsiSession.ParseAndCheckInteraction(expr)
                    collectErrors parseResults.Diagnostics res expr $"{doc} generated a parsing error"
                else
                    res)
            Array.empty
