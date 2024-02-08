module Anagram

open System
open System.Linq

let isAnagram (target: string) (source: string) =
    if target.Equals(source, StringComparison.OrdinalIgnoreCase) then
        false
    else
        let sort(str: string) = str.ToLower() |> Seq.sort

        (target |> sort).SequenceEqual(source |> sort)

let findAnagrams sources target =
    sources |> List.filter (isAnagram target)
