module MatchingBrackets

open System

let isPaired (input: string) =
    let brackets = "[]{}()" |> Set.ofSeq
    let filtered = input.ToCharArray() |> Array.filter brackets.Contains |> String
    let replaceMatchingBrackets (str: string) = str.Replace("[]", "").Replace("{}", "").Replace("()", "")
    
    let rec loop (remaining: string) =
        match remaining.Length with
        | 0 -> true
        | _  -> 
            let updated = replaceMatchingBrackets remaining
            match updated.Length = remaining.Length with
            | true -> false
            | false -> loop updated
        
    loop filtered
