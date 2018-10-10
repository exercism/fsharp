// This file was auto-generated based on version 1.6.1 of the canonical data.

module PhoneNumberTest

open FsUnit.Xunit
open Xunit

open PhoneNumber

[<Fact>]
let ``Cleans the number`` () =
    let expected: Result<uint64,string> = Ok 2234567890UL
    clean "(223) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cleans numbers with dots`` () =
    let expected: Result<uint64,string> = Ok 2234567890UL
    clean "223.456.7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cleans numbers with multiple spaces`` () =
    let expected: Result<uint64,string> = Ok 2234567890UL
    clean "223 456   7890   " |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when 9 digits`` () =
    let expected: Result<uint64,string> = Error "incorrect number of digits"
    clean "123456789" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when 11 digits does not start with a 1`` () =
    let expected: Result<uint64,string> = Error "11 digits must start with 1"
    clean "22234567890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Valid when 11 digits and starting with 1`` () =
    let expected: Result<uint64,string> = Ok 2234567890UL
    clean "12234567890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Valid when 11 digits and starting with 1 even with punctuation`` () =
    let expected: Result<uint64,string> = Ok 2234567890UL
    clean "+1 (223) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when more than 11 digits`` () =
    let expected: Result<uint64,string> = Error "more than 11 digits"
    clean "321234567890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid with letters`` () =
    let expected: Result<uint64,string> = Error "alphanumerics not permitted"
    clean "123-abc-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid with punctuations`` () =
    let expected: Result<uint64,string> = Error "punctuations not permitted"
    clean "123-@:!-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if area code starts with 0`` () =
    let expected: Result<uint64,string> = Error "area code cannot start with zero"
    clean "(023) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if area code starts with 1`` () =
    let expected: Result<uint64,string> = Error "area code cannot start with one"
    clean "(123) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if exchange code starts with 0`` () =
    let expected: Result<uint64,string> = Error "exchange code cannot start with zero"
    clean "(223) 056-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if exchange code starts with 1`` () =
    let expected: Result<uint64,string> = Error "exchange code cannot start with one"
    clean "(223) 156-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if area code starts with 0 on valid 11-digit number`` () =
    let expected: Result<uint64,string> = Error "area code cannot start with zero"
    clean "1 (023) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if area code starts with 1 on valid 11-digit number`` () =
    let expected: Result<uint64,string> = Error "area code cannot start with one"
    clean "1 (123) 456-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if exchange code starts with 0 on valid 11-digit number`` () =
    let expected: Result<uint64,string> = Error "exchange code cannot start with zero"
    clean "1 (223) 056-7890" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid if exchange code starts with 1 on valid 11-digit number`` () =
    let expected: Result<uint64,string> = Error "exchange code cannot start with one"
    clean "1 (223) 156-7890" |> should equal expected

