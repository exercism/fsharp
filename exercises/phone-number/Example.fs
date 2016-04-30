module PhoneNumber

open System

let parsePhoneNumber (input: string) = 
    let digits = input.ToCharArray() |> Array.filter (Char.IsDigit) |> String

    match digits.Length with
    | 10 -> Some digits
    | 11 when digits.Chars 0 = '1' ->  Some (digits.Substring(1))
    | _ -> None