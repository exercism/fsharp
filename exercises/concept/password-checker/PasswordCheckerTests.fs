module PasswordCheckerTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open PasswordChecker

[<Fact>]
[<Task(1)>]
let ``Error when password too short`` () =
    let expected: Result<string, PasswordError> = Error LessThan12Characters
    checkPassword "@bcd3fghijK" |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Error when password has no uppercase letters`` () =
    let expected: Result<string, PasswordError> = Error MissingUppercaseLetter
    checkPassword "@bcd3fghijkl" |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Error when password has no lowercase letters`` () =
    let expected: Result<string, PasswordError> = Error MissingLowercaseLetter
    checkPassword "@BCD3FGHIJKL" |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Error when password has no digits`` () =
    let expected: Result<string, PasswordError> = Error MissingDigit
    checkPassword "@bcdefghijkL" |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Error when password has no symbols`` () =
    let expected: Result<string, PasswordError> = Error MissingSymbol
    checkPassword "abcd3fghijkL" |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Ok when password is good with exclamation mark`` () =
    let password = "!1abcdefghiJ"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Ok when password is good with at symbol`` () =
    let password = "@2KLMNOPQRSt"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Ok when password is good with dollar sign`` () =
    let password = "$4abcdefghiJ"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(1)>]
let ``Ok when password is good with ampersand`` () =
    let password = "&7KLMNOPQRSt"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Insufficient length error message`` () =
    getStatusMessage (Error LessThan12Characters) |> should equal "Error: does not have at least 12 characters"

[<Fact>]
[<Task(2)>]
let ``Missing uppercase error message`` () =
    getStatusMessage (Error MissingUppercaseLetter) |> should equal "Error: does not have at least one uppercase letter"

[<Fact>]
[<Task(2)>]
let ``Missing lowercase error message`` () =
    getStatusMessage (Error MissingLowercaseLetter) |> should equal "Error: does not have at least one lowercase letter"

[<Fact>]
[<Task(2)>]
let ``Missing digit error message`` () =
    getStatusMessage (Error MissingDigit) |> should equal "Error: does not have at least one digit"

[<Fact>]
[<Task(2)>]
let ``Missing symbol error message`` () =
    getStatusMessage (Error MissingSymbol) |> should equal "Error: does not have at least one symbol"

[<Fact>]
[<Task(2)>]
let ``OK message`` () =
    getStatusMessage (Ok "foo") |> should equal "OK"
