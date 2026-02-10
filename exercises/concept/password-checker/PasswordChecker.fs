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
    failwith "Please implement this function"

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordRule>) : string =
    failwith "Please implement this function"
