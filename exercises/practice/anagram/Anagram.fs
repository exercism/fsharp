module Anagram

open System

let isAnagram (target: string) (source: string) =
    if target.Equals(source, StringComparison.OrdinalIgnoreCase) then
        false
    else
        let sort(str: string) =
            str.ToLower()
            |> Seq.sort
            |> Seq.toArray
            |> (function
            | chars -> String.Concat chars)

        (target |> sort) = (source |> sort)

let findAnagrams sources target =
    sources |> List.filter (isAnagram target)
