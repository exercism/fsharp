module ImprovedPasswordCheckerTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open ImprovedPasswordChecker

[<Fact>]
[<Task(2)>]
let ``Ok with valid password`` () =
    let password = "ABCdef123@&$"
    let expected: Result<string, PasswordError> = Ok password
    checkPassword password |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Missing digit error with twelve mixed-case letters and symbols`` () =
    let expected: Result<string, PasswordError> = Error PasswordError.MissingDigit
    checkPassword "ABCDEF$&*ghi" |> should equal expected

[<Fact>]
[<Task(2)>]
let ``Missing symbol error with twelve mixed-case letters and digits`` () =
    let expected: Result<string, PasswordError> = Error PasswordError.MissingSymbol
    checkPassword "ABCDEF123ghi" |> should equal expected

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
let ``Error on some of the rules with twelve uppercase letters`` () =
    let expected: Result<string, PasswordError> = Error (
        PasswordError.MissingLowercaseLetter ||| 
        PasswordError.MissingDigit ||| 
        PasswordError.MissingSymbol
    )
    checkPassword "ABCDEFGHIJKL" |> should equal expected

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
[<Task(3)>]
let ``No phrases for Ok result`` () =
    getStatusPhrases (Ok "") |> should equal ([]: string list)

[<Fact>]
[<Task(3)>]
let ``One phrase for insufficient length`` () =
    let actual = getStatusPhrases (Error PasswordError.LessThan12Characters)
    set actual |> should equal (set ["12 characters"])

[<Fact>]
[<Task(3)>]
let ``Two phrases for insufficient length + missing uppercase letter`` () =
    let givenResult = Error (PasswordError.LessThan12Characters ||| PasswordError.MissingUppercaseLetter)
    let expected = ["12 characters"; "uppercase letter"]
    set (getStatusPhrases givenResult) |> should equal (set expected)

[<Fact>]
[<Task(3)>]
let ``Three phrases for insufficient length + missing uppercase letter + missing lowercase letter`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter
    )
    let expected = ["12 characters"; "uppercase letter"; "lowercase letter"]
    set (getStatusPhrases givenResult) |> should equal (set expected)

[<Fact>]
[<Task(3)>]
let ``Four phrases for all errors except missing symbol`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter |||
        PasswordError.MissingDigit
    )
    let expected = ["12 characters"; "uppercase letter"; "lowercase letter"; "digit"]
    set (getStatusPhrases givenResult) |> should equal (set expected)

[<Fact>]
[<Task(3)>]
let ``All phrases for all errors`` () =
    let givenResult = Error (
        PasswordError.LessThan12Characters |||
        PasswordError.MissingUppercaseLetter |||
        PasswordError.MissingLowercaseLetter |||
        PasswordError.MissingDigit |||
        PasswordError.MissingSymbol
    )
    let expected = Set ["12 characters"; "uppercase letter"; "lowercase letter"; "digit"; "symbol"]
    set (getStatusPhrases givenResult) |> should equal (set expected)
