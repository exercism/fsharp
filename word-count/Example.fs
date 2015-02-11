module Phrase

open System.Text.RegularExpressions

type Phrase(phrase: string) =

    member this.wordCount() = 
        Regex.Matches(phrase.ToLowerInvariant(), @"\w+('\w+)*") 
        |> Seq.cast<Match> 
        |> Seq.groupBy (fun m -> m.Value)
        |> Seq.map (fun (word, occurrences) -> word, occurrences |> Seq.length)                     
        |> Map.ofSeq