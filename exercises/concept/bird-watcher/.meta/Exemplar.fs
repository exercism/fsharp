module BirdWatcher

let lastWeek: int [] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday (counts: int []) = counts.[5]

let total (counts: int []) = Array.sum counts

let dayWithoutBirds (counts: int []) = Array.contains 0 counts

let incrementTodaysCount (counts: int []): int [] =
    counts.[6] <- counts.[6] + 1
    counts

let oddWeek (counts: int []) =
    match counts with
    | [| _; 0; _; 0; _; 0; _ |]
    | [| _; 10; _; 10; _; 10; _ |]
    | [| 5; _; 5; _; 5; _; 5|] -> true
    | _ -> false
