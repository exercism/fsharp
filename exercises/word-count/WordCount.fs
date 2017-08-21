module Phrase

open System.Text.RegularExpressions

let wordCount (phrase: string) = 
    Regex.Matches(phrase.ToLowerInvariant(), @"\w+('\w+)*") 
    |> Seq.cast<Match> 
    |> Seq.countBy (fun m -> m.Value)
    |> Map.ofSeq