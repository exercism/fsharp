//
// Permission to use, copy, modify, and/or distribute this software for any purpose
// with or without fee is hereby granted.
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH
// REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY
// AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,
// INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM
// LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE
// OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR
// PERFORMANCE OF THIS SOFTWARE.
//
namespace CodeFenceChecker

[<AutoOpen>]
module Parser =
    open FSharp.Compiler.SourceCodeServices

    let private collectErrors (inErrs: FSharpErrorInfo []) (outErrs: string []) (expr: string) (msg: string) =
        inErrs
        |> Array.filter (fun e -> e.Severity = FSharpErrorSeverity.Error)
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
                    let parseResults, _, _ = fsiSession.ParseAndCheckInteraction(expr) |> Async.RunSynchronously
                    collectErrors parseResults.Errors res expr $"{doc} generated a parsing error"
                else
                    res)
            Array.empty
