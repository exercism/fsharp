module PhoneNumber

open System

let hasPunctuation(input: string) =
    input |> Seq.exists Char.IsPunctuation

let hasLetters(input: string) =
    input |> Seq.exists Char.IsLetter

let clean input : Result<uint64, string> =
    let clean oldValue (input: string) = input.Replace(oldValue, "")
    let trim(input: string) = input.Trim()

    let cleaned =
        input
        |> clean "."
        |> clean "("
        |> clean ")"
        |> clean "-"
        |> clean "+"
        |> clean " "
        |> trim

    if (cleaned |> hasLetters) then
        Error "letters not permitted"
    elif (cleaned |> hasPunctuation) then
        Error "punctuations not permitted"
    else
        match cleaned.Length with
        | 10 -> Ok(cleaned |> uint64)
        | 11 when cleaned[0] = '1' -> Ok(cleaned[1..] |> uint64)
        | 11 -> Error "11 digits must start with 1"
        | x when x > 11 -> Error "more than 11 digits"
        | _ -> Error "incorrect number of digits"
