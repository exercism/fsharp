module Octal

let isValid char = char >= '0' && char <= '7'

let charToDecimal char = (int)char - (int)'0'

let toDecimal (input: string) = 
    let chars = input.ToCharArray()
    if Array.forall isValid chars then Array.fold (fun acc c -> acc * 8 + charToDecimal c) 0 chars
    else 0