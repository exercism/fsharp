module ImprovedPasswordChecker

type PasswordError =
    | LessThan12Characters
    | MissingUppercaseLetter
    | MissingLowercaseLetter
    | MissingDigit
    | MissingSymbol

/// Validate the given password against the rules defined in the instructions. If it meets all
/// of the rules, return a result indicating success; otherwise return a result indicating
/// failure with an error value indicating all of the rules that were violated.
let checkPassword (password: string) : Result<string, PasswordError> =
    failwith "Please implement this function"

/// Return a list of human-readable phrases indicating the meaning of the given result value.
let getStatusPhrases (result: Result<string, PasswordError>) : string list =
    failwith "Please implement this function"
