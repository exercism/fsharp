module Isogram

open System

let normalize str = str |> Seq.filter Char.IsLetter |> Seq.map Char.ToLower |> Seq.toList

let isogram str = 
    let normalized = normalize str
    Seq.length normalized = (normalized |> Seq.distinct |> Seq.length) 

