module Tests

open FsUnit.Xunit
open Xunit

open PasswordChecker

[<Fact>]
let ``Error on blank string`` () =
    let expected: Result<string, PasswordRule> = Error AtLeast12Characters
    checkPassword "" |> should equal expected

[<Fact>]
let ``Error when password too short`` () =
    let expected: Result<string, PasswordRule> = Error AtLeast12Characters
    checkPassword "@bcd3fghijK" |> should equal expected

[<Fact>]
let ``Error when password has no uppercase letters`` () =
    let expected: Result<string, PasswordRule> = Error AtLeastOneUppercaseLetter
    checkPassword "@bcd3fghijkl" |> should equal expected

[<Fact>]
let ``Error when password has no lowercase letters`` () =
    let expected: Result<string, PasswordRule> = Error AtLeastOneLowercaseLetter
    checkPassword "@BCD3FGHIJKL" |> should equal expected

[<Fact>]
let ``Error when password has no digits`` () =
    let expected: Result<string, PasswordRule> = Error AtLeastOneDigit
    checkPassword "@bcdefghijkL" |> should equal expected

[<Fact>]
let ``Error when password has no symbols`` () =
    let expected: Result<string, PasswordRule> = Error AtLeastOneSymbol
    checkPassword "abcd3fghijkL" |> should equal expected

[<Theory>]
[<InlineData("!1abcdefghiJ")>]
[<InlineData("@2KLMNOPQRSt")>]
[<InlineData("$4abcdefghiJ")>]
[<InlineData("&7KLMNOPQRSt")>]
let ``Ok when password is good`` (password: string) =
    let expected: Result<string, PasswordRule> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
let ``Insufficient length error message`` () =
    getStatusMessage (Error AtLeast12Characters) |> should equal "Error: does not have at least 12 characters"

[<Fact>]
let ``Missing uppercase error message`` () =
    getStatusMessage (Error AtLeastOneUppercaseLetter) |> should equal "Error: does not have at least one uppercase letter"

[<Fact>]
let ``Missing lowercase error message`` () =
    getStatusMessage (Error AtLeastOneLowercaseLetter) |> should equal "Error: does not have at least one lowercase letter"

[<Fact>]
let ``Missing digit error message`` () =
    getStatusMessage (Error AtLeastOneDigit) |> should equal "Error: does not have at least one digit"

[<Fact>]
let ``Missing symbol error message`` () =
    getStatusMessage (Error AtLeastOneSymbol) |> should equal "Error: does not have at least one symbol"

[<Fact>]
let ``OK message`` () =
    getStatusMessage (Ok "foo") |> should equal "OK"
