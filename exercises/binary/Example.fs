module Binary

type Binary(input: string) =
    let rec toDecimalLoop acc input = 
        if input = "" then acc
        else 
            let head = input.Chars 0
            let tail = input.Substring 1
            match head with
                | '0' -> toDecimalLoop (acc * 2) tail
                | '1' -> toDecimalLoop (acc * 2 + 1) tail
                | _   -> 0   

    member this.toDecimal() = toDecimalLoop 0 input