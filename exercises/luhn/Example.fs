module Luhn

type Luhn(number:int64) =
        
    let digit c = (int)c - (int)'0'
    let digits = number.ToString() |> Seq.map digit

    let addend index digit = 
        if (index % 2 = 0) then digit else 
        if (digit >= 5) then digit * 2 - 9 
        else digit * 2

    member this.checkDigit = number % 10L
    member this.addends = digits |> List.ofSeq |> List.rev |> List.mapi addend |> List.rev
    member this.checksum = (this.addends |> List.sum) % 10
    member this.valid = this.checksum = 0

    static member create(target:int64) = 
        let targetNumber = target * 10L
        let targetLuhn = Luhn(targetNumber)

        if targetLuhn.valid then targetNumber
        else targetNumber + 10L - (int64)targetLuhn.checksum