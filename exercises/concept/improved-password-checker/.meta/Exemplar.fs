module ImprovedPasswordChecker

open System

[<Flags>]
type PasswordError =
    | None = 0
    | LessThan12Characters = 1
    | MissingUppercaseLetter = 2
    | MissingLowercaseLetter = 4
    | MissingDigit = 8
    | MissingSymbol = 16

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure with an error value indicating all of the rules that were violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    let errors = (
        [
            ((fun (s: string) -> s.Length >= 12), PasswordError.LessThan12Characters);
            (String.exists System.Char.IsDigit, PasswordError.MissingDigit);
            (String.exists System.Char.IsLower, PasswordError.MissingLowercaseLetter);
            (String.exists System.Char.IsUpper, PasswordError.MissingUppercaseLetter);
            (String.exists (fun c -> "!@#$%^&*".Contains c), PasswordError.MissingSymbol)
        ]
        |> List.filter (fun (test, _) -> password |> test |> not)
        |> List.map snd
        |> List.fold (|||) PasswordError.None 
    )
    if errors = PasswordError.None then
        Ok password
    else
        Error errors

/// Return a list of human-readable phrases indicating the meaning of the given result value.
let getStatusPhrases (result: Result<string, PasswordError>) : string list =
    match result with
    | Error e -> (
            [
                (PasswordError.LessThan12Characters, "12 characters");
                (PasswordError.MissingUppercaseLetter, "uppercase letter");
                (PasswordError.MissingLowercaseLetter, "lowercase letter");
                (PasswordError.MissingDigit, "digit");
                (PasswordError.MissingSymbol, "symbol")
            ] 
            |> List.filter (fun (flag, _) -> e.HasFlag(flag))
            |> List.map snd
        )
    | _ -> []
