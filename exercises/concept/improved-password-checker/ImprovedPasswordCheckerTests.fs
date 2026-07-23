module ImprovedPasswordCheckerTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open ImprovedPasswordChecker

[<Fact>]
[<Task(2)>]
let ``Error on all rules with blank password`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.LessThan12Characters ||| 
        PasswordError.MissingUppercaseLetter ||| 
        PasswordError.MissingLowercaseLetter ||| 
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Error on most of the rules with single uppercase letter`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.LessThan12Characters ||| 
        PasswordError.MissingLowercaseLetter ||| 
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "A" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Error on most of the rules with eleven uppercase letters`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.LessThan12Characters ||| 
        PasswordError.MissingLowercaseLetter ||| 
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "ABCDEFGHIJK" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Error on some of the rules with twelve uppercase letters`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.MissingLowercaseLetter ||| 
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "ABCDEFGHIJKL" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Error on two rules with thirteen mixed-case letters`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "AbCdEfGhIjKlM" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Missing symbol error with twelve mixed-case letters and digits`` () =
    let expected: Result<string, PasswordError> = Error PasswordError.MissingSymbol
    checkPassword "ABCDEF123ghi" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Missing digit error with twelve mixed-case letters and symbols`` () =
    let expected: Result<string, PasswordError> = Error PasswordError.MissingDigit
    checkPassword "ABCDEF$&*ghi" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Ok with valid password`` () =
    let password = "ABCdef123@&$"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(3)>]
let ``Insufficient length`` () =
    getStatusPhrases (Error PasswordError.LessThan12Characters) |> should equal (Set ["12 characters"])

[<Fact>]
[<Task(3)>]
let ``Insufficient length + missing uppercase letter`` () =
    let givenResult = Error (PasswordError.LessThan12Characters ||| PasswordError.MissingUppercaseLetter)
    let expected = Set ["12 characters"; "uppercase letter"]
    getStatusPhrases givenResult |> should equal expected

[<Fact>]
[<Task(3)>]
let ``Insufficient length + missing uppercase letter + missing lowercase letter`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter
    )
    let expected = Set ["12 characters"; "uppercase letter"; "lowercase letter"]
    getStatusPhrases givenResult |> should equal expected

[<Fact>]
[<Task(3)>]
let ``All errors except missing symbol`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter |||
        PasswordError.MissingDigit
    )
    let expected = Set ["12 characters"; "uppercase letter"; "lowercase letter"; "digit"]
    getStatusPhrases givenResult |> should equal expected

[<Fact>]
[<Task(3)>]
let ``All errors`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter |||
        PasswordError.MissingDigit |||
        PasswordError.MissingSymbol
    )
    let expected = Set ["12 characters"; "uppercase letter"; "lowercase letter"; "digit"; "symbol"]
    getStatusPhrases givenResult |> should equal expected
