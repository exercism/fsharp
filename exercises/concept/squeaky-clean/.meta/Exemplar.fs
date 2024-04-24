module SqueakyClean

open System

let transform (c: char) : string =    
    if c = '-' then
        "_"
    elif c >= 'α' && c <= 'ω'  then
        "?"
    elif Char.IsWhiteSpace(c) || Char.IsNumber(c) then
        ""
    elif Char.IsUpper(c) then
        $"-{Char.ToLower(c)}"
    else
        c.ToString()

let clean (identifier: string): string =
    String.collect transform identifier 
