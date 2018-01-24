﻿module WordCount

open System.Text.RegularExpressions

let countwords (phrase: string) = 
    Regex.Matches(phrase.ToLowerInvariant(), @"\w+('\w+)*") 
    |> Seq.cast<Match> 
    |> Seq.countBy (fun m -> m.Value)
    |> Map.ofSeq