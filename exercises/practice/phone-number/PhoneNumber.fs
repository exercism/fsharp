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

let cleanNumber(input: string) =
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

let validateLength(cleaned: string) =
    match cleaned.Length with
    | 10
    | 11 -> Ok(cleaned)
    | x when x > 11 -> Error "more than 11 digits"
    | _ -> Error "incorrect number of digits"

let validateCountryCode(input: string) =
    match input.Length, input[0] with
    | 10, _ -> Ok input
    | 11, '1' -> Ok input
    | _ -> Error "11 digits must start with 1"

let removeCountryCode(input: string) =
    if (input.Length = 11) then input[1..] else input

let validateAreaCode(input: string) =
    match input[0] with
    | '0' -> Error "area code cannot start with zero"
    | '1' -> Error "area code cannot start with one"
    | _ -> Ok input

let validateExchangeCode(input: string) =
    match input[3] with
    | '0' -> Error "exchange code cannot start with zero"
    | '1' -> Error "exchange code cannot start with one"
    | _ -> Ok input

let clean input : Result<uint64, string> =
    input
    |> cleanNumber
    |> validateLetters
    |> Result.bind validatePunctuation
    |> Result.bind validateLength
    |> Result.bind validateCountryCode
    |> Result.map removeCountryCode
    |> Result.bind validateAreaCode
    |> Result.bind validateExchangeCode
    |> Result.map uint64
