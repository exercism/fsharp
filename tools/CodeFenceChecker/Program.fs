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
