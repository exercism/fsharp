module Anagram

open System

let normalize (str:string) = new string(str.ToLowerInvariant().ToCharArray() |> Array.sort)    
let unequal str other = not (String.Equals(str, other, StringComparison.InvariantCultureIgnoreCase))
       
let findAnagrams sources target = 
    let normalizedTarget = normalize target
    let isMatch str = normalize str = normalizedTarget && unequal str target
    
    List.filter isMatch sources