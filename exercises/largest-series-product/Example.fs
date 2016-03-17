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

let largestProduct input seriesLength = 
    if seriesLength > String.length input then failwith "Slice size is too big"
    else 
        input 
        |> digits 
        |> slices seriesLength
        |> List.map (List.fold (*) 1)
        |> List.max