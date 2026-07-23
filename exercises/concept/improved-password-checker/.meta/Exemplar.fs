module ImprovedPasswordChecker

open System

[<Flags>]
type PasswordError =
    | LessThan12Characters = 1
    | MissingUppercaseLetter = 2
    | MissingLowercaseLetter = 4
    | MissingDigit = 8
    | MissingSymbol = 16

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure with an error value indicating all of the rules that were violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    let mutable errors = (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter |||
        PasswordError.MissingDigit |||
        PasswordError.MissingSymbol
    )
    if password.Length >= 12 then
        errors <- errors &&& ~~~PasswordError.LessThan12Characters
    for (charTest, flag) in [
        (System.Char.IsUpper, PasswordError.MissingUppercaseLetter);
        (System.Char.IsLower, PasswordError.MissingLowercaseLetter);
        (System.Char.IsDigit, PasswordError.MissingDigit);
        ((fun c -> "!@#$%^&*".Contains c), PasswordError.MissingSymbol)
    ] do
        if password |> String.exists charTest then
            errors <- errors &&& ~~~flag

    if int errors = 0 then
        Ok password
    else
        Error errors

/// Return a set of human-readable phrases indicating the meaning of the given result value.
let getStatusPhrases (result: Result<string, PasswordError>) : Set<string> =
    let mutable phrases: Set<string> = Set [ ]
    match result with
    | Error errors ->
        for (flag, phrase) in [
            (PasswordError.LessThan12Characters, "12 characters");
            (PasswordError.MissingUppercaseLetter, "uppercase letter");
            (PasswordError.MissingLowercaseLetter, "lowercase letter");
            (PasswordError.MissingDigit, "digit");
            (PasswordError.MissingSymbol, "symbol")
        ] do
            if errors.HasFlag(flag) then
                phrases <- phrases.Add(phrase)
    | Ok _ -> ()
    phrases
