module Octal

type Octal(input: string) =
    let rec toDecimalLoop acc input = 
        if input = "" then acc
        else 
            let head = input.Chars 0
            let tail = input.Substring 1
            match head with
                | x when x >= '0' && x <= '7' -> toDecimalLoop (acc * 8 + (int)head - (int)'0') tail
                | _  -> 0   

    member this.toDecimal() = toDecimalLoop 0 input