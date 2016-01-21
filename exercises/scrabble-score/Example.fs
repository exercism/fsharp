module Scrabble

open System

type Scrabble(word:string) =

    let letterScores = [("AEIOULNRST", 1); ("DG", 2); ("BCMP", 3); ("FHVWY", 4); ("K", 5); ("JX", 9); ("QZ", 10)] 
                       |> List.map (fun (letters, score) -> letters |> Seq.map (fun letter -> (letter, score))) 
                       |> Seq.concat 
                       |> Map.ofSeq

    let scoreLetter letter = defaultArg (Map.tryFind letter letterScores) 0

    member val score = word.ToUpperInvariant() |> Seq.sumBy scoreLetter

    static member wordScore(word) = Scrabble(word).score