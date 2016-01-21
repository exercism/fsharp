module Anagram

open System

type Anagram(target) =   

    let normalize (str:string) = new string(str.ToLowerInvariant().ToCharArray() |> Array.sort)
    let normalizedTarget = normalize target
    let unequal str other = not (String.Equals(str, target, StringComparison.InvariantCultureIgnoreCase))
    
    let isMatch str = normalize str = normalizedTarget && unequal str target

    member this.Match sources = List.filter isMatch sources