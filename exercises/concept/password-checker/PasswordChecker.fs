module PasswordChecker

type PasswordRule =
    | AtLeast12Characters
    | AtLeastOneUppercaseLetter
    | AtLeastOneLowercaseLetter
    | AtLeastOneDigit
    | AtLeastOneSymbol

let checkPassword (password: string) : Result<string, PasswordRule> =
    failwith "Please implement this function"

let getStatusMessage (result: Result<string, PasswordRule>) : string =
    failwith "Please implement this function"
