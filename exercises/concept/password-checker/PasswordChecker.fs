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
    failwith "Please implement this function"

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordError>) : string =
    failwith "Please implement this function"
