module Luhn
        
let digit c = (int)c - (int)'0'
let digits number = number.ToString() |> Seq.map digit

let addend index digit = 
    if (index % 2 = 0) then digit else 
    if (digit >= 5) then digit * 2 - 9 
    else digit * 2

let checkDigit (number:int64) = number % 10L

let addends (number:int64) = 
    number 
    |> digits 
    |> List.ofSeq 
    |> List.rev 
    |> List.mapi addend 
    |> List.rev

let checksum (number:int64) = (number |> addends |> List.sum) % 10

let valid (number:int64) = checksum number = 0

let create (target:int64) = 
    let targetNumber = target * 10L

    if valid targetNumber then targetNumber
    else targetNumber + 10L - (int64)(checksum targetNumber)