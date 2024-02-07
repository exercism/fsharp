module Acronym

open System

let abbreviate(phrase: string) =
    phrase
        .ToUpper()
        .Split([| ' '; '-'; '_' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun s -> s[0])
    |> String.Concat
