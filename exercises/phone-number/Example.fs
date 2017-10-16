module PhoneNumber

open System

let private validate (input: string) =
    let isStartDigit digit = List.contains digit ['2'..'9']

    if isStartDigit input.[0] && isStartDigit input.[3] then
        Some input
    else 
        None

let clean (input: string) = 
    let digits = input.ToCharArray() |> Array.filter (Char.IsDigit) |> String

    match digits.Length with
    | 10 -> validate digits
    | 11 when digits.Chars 0 = '1' ->  validate (digits.Substring(1))
    | _ -> None