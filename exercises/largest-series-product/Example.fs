module LargestSeriesProduct

open System

let digits (str: string) = 
    str
    |> Seq.map (string >> int)
    |> Seq.toList

let slices size list = 
    let slice i = 
        list 
        |> List.skip i 
        |> List.take size

    let sliceCount = List.length list + 1 - size

    List.init sliceCount slice
let isInputHasAllDigits input =
    input
    |> Seq.forall Char.IsDigit
let largestProduct input seriesLength = 
    match input with 
    | l when String.length l < seriesLength -> -1
    | l when String.length l = 0 && seriesLength > 0 -> -1
    | l when seriesLength < 0 -> -1 
    | l when isInputHasAllDigits l -> -1
    | _ ->   
        input 
        |> digits 
        |> slices seriesLength
        |> List.map (List.fold (*) 1)
        |> List.max