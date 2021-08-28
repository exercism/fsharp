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

module Program =
    [<EntryPoint>]
    let main argv =
        let mutable exitStatus = 0
        let mutable errors = Array.empty

        try
            let matchArgSwitch (a: string) = a.ToLower().Equals("-not")

            // exclude paths after the "-Not" switch
            let included = argv |> Array.takeWhile (not << matchArgSwitch)

            // get the list of excluded paths, if any
            let ignored =
                argv
                |> Array.tryFindIndex matchArgSwitch
                |> function
                | Some i -> Array.splitAt i argv |> snd
                | None -> Array.except included argv
                |> Array.tail // remove the "-Not" switch
                |> Array.map (fun (path: string) -> path.Replace('/', sep))

            included
            |> Array.iter (fun dir -> errors <- parse (collectLines dir ignored) |> Array.append errors)

        with exc ->
            printfn $"{exc.GetType().Name}: {exc.Message}"
            exitStatus <- 1

        if (not << Array.isEmpty) errors then
            for e in errors do
                eprintfn $"{nl}{e}"

            exitStatus <- 1

        exitStatus
