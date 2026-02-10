module PasswordChecker

type PasswordRule =
    | AtLeast12Characters
    | AtLeastOneUppercaseLetter
    | AtLeastOneLowercaseLetter
    | AtLeastOneDigit
    | AtLeastOneSymbol

/// Validate the given password against the rules defined in `PasswordRule`. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure and the rule that was violated.
let checkPassword (password: string) : Result<string, PasswordRule> =
    if password.Length < 12 then
        Error AtLeast12Characters
    elif password |> String.exists System.Char.IsUpper |> not then
        Error AtLeastOneUppercaseLetter
    elif password |> String.exists System.Char.IsLower |> not then
        Error AtLeastOneLowercaseLetter
    elif password |> String.exists System.Char.IsDigit |> not then
        Error AtLeastOneDigit
    elif password |> String.exists (fun c -> "!@#$%^&*".Contains c) |> not then
        Error AtLeastOneSymbol
    else Ok password

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordRule>) : string =
    let preamble = "Error: does not have at least "
    match result with
    | Error AtLeast12Characters -> preamble + "12 characters"
    | Error AtLeastOneUppercaseLetter -> preamble + "one uppercase letter"
    | Error AtLeastOneLowercaseLetter -> preamble + "one lowercase letter"
    | Error AtLeastOneDigit -> preamble + "one digit"
    | Error AtLeastOneSymbol -> preamble + "one symbol"
    | Ok _ -> "OK"
