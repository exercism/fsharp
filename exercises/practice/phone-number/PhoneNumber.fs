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

let validateCountryCode(input: char array) =
    match input.Length, (input |> Array.tryHead) with
    | 10, _ -> Ok input
    | 11, Some '1' -> Ok input
    | _ -> Error "11 digits must start with 1"

let removeCountryCode(input: char array) =
    if (input.Length = 11) then input[1..] else input

let validateAreaCode(input: char array) =
    match Array.tryHead input with
    | Some '0' -> Error "area code cannot start with zero"
    | Some '1' -> Error "area code cannot start with one"
    | None -> Error "Empty phone!"
    | _ -> Ok input

let validateExchangeCode(input: char array) =
    match input |> Array.tryItem 3 with
    | Some '0' -> Error "exchange code cannot start with zero"
    | Some '1' -> Error "exchange code cannot start with one"
    | None -> Error "Invalid phone!"
    | _ -> Ok input

let clean input : Result<uint64, string> =
    input
    |> cleanNumber
    |> validateLetters
    |> Result.bind validatePunctuation
    |> Result.bind validateLength
    |> Result.map (fun s -> s.ToCharArray())
    |> Result.bind validateCountryCode
    |> Result.map removeCountryCode
    |> Result.bind validateAreaCode
    |> Result.bind validateExchangeCode
    |> Result.map (fun array -> new string(array) |> uint64)
