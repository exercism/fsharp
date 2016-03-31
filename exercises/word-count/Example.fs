module Phrase

open System.Text.RegularExpressions

let wordCount (phrase: string) = 
    Regex.Matches(phrase.ToLowerInvariant(), @"\w+('\w+)*") 
    |> Seq.cast<Match> 
    |> Seq.groupBy (fun m -> m.Value)
    |> Seq.map (fun (word, occurrences) -> word, occurrences |> Seq.length)                     
    |> Map.ofSeq