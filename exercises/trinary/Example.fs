module Trinary

type Trinary(input: string) =
    let rec toDecimalLoop acc input = 
        if input = "" then acc
        else 
            let head = input.Chars 0
            let tail = input.Substring 1
            match head with
                | '0' | '1' | '2' -> toDecimalLoop (acc * 3 + (int)head - (int)'0') tail
                | _  -> 0   

    member this.toDecimal() = toDecimalLoop 0 input