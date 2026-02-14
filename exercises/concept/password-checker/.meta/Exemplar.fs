module PasswordChecker

type PasswordError =
    | LessThan12Characters
    | MissingUppercaseLetter
    | MissingLowercaseLetter
    | MissingDigit
    | MissingSymbol

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure and an error indicating which rule was violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    if password.Length < 12 then
        Error LessThan12Characters
    elif password |> String.exists System.Char.IsUpper |> not then
        Error MissingUppercaseLetter
    elif password |> String.exists System.Char.IsLower |> not then
        Error MissingLowercaseLetter
    elif password |> String.exists System.Char.IsDigit |> not then
        Error MissingDigit
    elif password |> String.exists (fun c -> "!@#$%^&*".Contains c) |> not then
        Error MissingSymbol
    else Ok password

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordError>) : string =
    let preamble = "Error: does not have at least "
    match result with
    | Error LessThan12Characters -> preamble + "12 characters"
    | Error MissingUppercaseLetter -> preamble + "one uppercase letter"
    | Error MissingLowercaseLetter -> preamble + "one lowercase letter"
    | Error MissingDigit -> preamble + "one digit"
    | Error MissingSymbol -> preamble + "one symbol"
    | Ok _ -> "OK"
