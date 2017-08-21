module Series

open System

let charToDigit c = c.ToString() |> Int32.Parse 
let digits str = str |> List.ofSeq |> List.map charToDigit
let slice length input = Seq.take length input |> List.ofSeq

let rec slicesHelper length remainder acc = 
    if remainder |> List.length < length then acc |> List.rev
    else slicesHelper length (remainder |> List.tail) (slice length remainder:: acc)

let slices (str:string) length = 
    if length > str.Length then invalidArg "length" "Slice length must not be than input length"
    else slicesHelper length (digits str) []