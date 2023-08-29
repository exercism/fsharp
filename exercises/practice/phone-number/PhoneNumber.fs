module PhoneNumber

open System

let validatePunctuation(input: string) =
    if input |> Seq.exists Char.IsPunctuation then
        Error "punctuations not permitted"
    else
        Ok input

let validateLetters(input: string) =
    if input |> Seq.exists Char.IsLetter then
        Error "letters not permitted"
    else
        Ok input

let cleanNumber (input:string) =
    let clean oldValue (input: string) = input.Replace(oldValue, "")
    let trim(input: string) = input.Trim()

    input
        |> clean "."
        |> clean "("
        |> clean ")"
        |> clean "-"
        |> clean "+"
        |> clean " "
        |> trim
        
let validate(cleaned: string) =
    match cleaned.Length with
    | 10 -> Ok(cleaned |> uint64)
    | 11 when cleaned[0] = '1' -> Ok(cleaned[1..] |> uint64)
    | 11 -> Error "11 digits must start with 1"
    | x when x > 11 -> Error "more than 11 digits"
    | _ -> Error "incorrect number of digits"

let clean input : Result<uint64, string> =
    let x = input |> cleanNumber |> validateLetters |> Result.bind validatePunctuation |> Result.bind validate

    x

// else
//     match cleaned.Length with
//     | 10 -> Ok(cleaned |> uint64)
//     | 11 when cleaned[0] = '1' -> Ok(cleaned[1..] |> uint64)
//     | 11 -> Error "11 digits must start with 1"
//     | x when x > 11 -> Error "more than 11 digits"
//     | _ -> Error "incorrect number of digits"
