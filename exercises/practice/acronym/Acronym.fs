module Acronym

open System

let abbreviate(phrase: string) =
    phrase
        .Replace('-', ' ')
        .Replace('_', ' ')
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun s -> s[0] |> Char.ToUpper |> string)
    |> String.concat ""
