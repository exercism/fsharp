module Hexadecimal

open System

let private isValid char = "0123456789ABCDEF".Contains(string char)

let private charToDecimal (char: char) =
    if Char.IsDigit(char) then (int)char - (int)'0'
    else (int)(char) - (int)'A' + 10

let toDecimal(input: string) = 
    let chars = input.ToUpperInvariant().ToCharArray()
    if Array.forall isValid chars then Array.fold (fun acc c -> acc * 16 + charToDecimal c) 0 chars
    else 0