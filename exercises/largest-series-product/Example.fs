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

let allDigits input =
    input
    |> Seq.forall Char.IsDigit
    
let isInvalidCase input seriesLength =
    let inputLenth = String.length input
    
    inputLenth < seriesLength 
    || inputLenth = 0 && seriesLength > 0 
    || seriesLength < 0 
    || not (allDigits input)

let largestProduct input seriesLength = 
    match isInvalidCase input seriesLength with 
    | true -> -1
    | false ->   
        input 
        |> digits 
        |> slices seriesLength
        |> List.map (List.fold (*) 1)
        |> List.max