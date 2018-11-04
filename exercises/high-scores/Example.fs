module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int = List.last values

let highest (values: int list): int = List.max values

let top  (values: int list): int list = values |> List.sortDescending |> List.truncate 3

let report (values: int list): string =
    let latest' = latest values
    let highest' = highest values
    let difference = highest' - latest'
    let comparedDifference = if difference = 0 then "" else sprintf "%d short of " difference

    sprintf "Your latest score was %d. That's %syour personal best!" latest' comparedDifference