module Acronym
    
open System
open System.Text.RegularExpressions

let abbreviate (phrase:string) =  
    let acronymChar = Char.ToUpperInvariant << Seq.head
    let words = Regex.Matches(phrase, "[A-Z]+[a-z']*|[a-z']+")
    let chars = [|for word in words do yield word.Value |> acronymChar|]
    String chars