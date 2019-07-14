module PhoneNumber

open System

let private deleteFillers (input: string):string = 
    input
    |> Seq.filter (fun c -> not (List.contains c ['+';'.';'-';' ';'(';')']))
    |> String.Concat

let private checkNumberLength (input:string): Result<string, string> = 
    match String.length input with
    | 10 -> Ok input
    | 11 when input.[0] = '1'-> Ok (input.Substring 1)
    | 11 -> Error "11 digits must start with 1"
    | a when a > 11 -> Error "more than 11 digits"
    | _ -> Error "incorrect number of digits"

let private checkNoneNumericChars (input:string): Result<string, string> =
    match input with
    | i when Seq.exists Char.IsLetter i -> Error "letters not permitted"
    | i when Seq.exists Char.IsPunctuation i -> Error "punctuations not permitted"
    | i when Seq.forall Char.IsNumber i -> Ok input
    | _ -> Error "some char is not a number"

let private checkAreaCode (input:string): Result<string, string> =
    match input with
    | i when i.[0] = '0' -> Error "area code cannot start with zero"
    | i when i.[0] = '1' -> Error "area code cannot start with one"
    | _ -> Ok input

let private checkExchangeCode (input:string): Result<string, string> =
    match input with
    | i when i.[3] = '0' -> Error "exchange code cannot start with zero"
    | i when i.[3] = '1' -> Error "exchange code cannot start with one"
    | _ -> Ok input

let clean (input: string): Result<uint64, string> = 
    input
    |> deleteFillers
    |> checkNumberLength
    |> Result.bind checkNoneNumericChars
    |> Result.bind checkAreaCode
    |> Result.bind checkExchangeCode
    |> Result.bind (fun x -> Ok (uint64 x))