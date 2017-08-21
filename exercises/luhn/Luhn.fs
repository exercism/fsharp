module Luhn

let private digit c = (int)c - (int)'0'
let private digits number = number.ToString() |> Seq.map digit

let private addend index digit = 
    if (index % 2 = 0) then digit else 
    if (digit >= 5) then digit * 2 - 9 
    else digit * 2

let private addends number = 
    number
    |> List.ofSeq 
    |> List.rev 
    |> List.mapi addend 
    |> List.rev

let private checksum number = (number |> digits |> addends |> List.sum) % 10

let valid (number : string) =
    let noSpaces = number.Replace(" ", "")
    match Seq.length noSpaces with
    | 0 | 1 -> false
    | _ ->
        match Seq.forall (fun c -> c >= '0' && c <= '9') noSpaces with
        | false -> false
        | true  -> checksum noSpaces = 0