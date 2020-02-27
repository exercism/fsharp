// This file was auto-generated based on version 1.2.0 of the canonical data.

module GrainsTests

open FsUnit.Xunit
open Xunit

open Grains

[<Fact>]
let ``1`` () =
    let expected: Result<uint64,string> = Ok 1UL
    square 1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``2`` () =
    let expected: Result<uint64,string> = Ok 2UL
    square 2 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``3`` () =
    let expected: Result<uint64,string> = Ok 4UL
    square 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``4`` () =
    let expected: Result<uint64,string> = Ok 8UL
    square 4 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``16`` () =
    let expected: Result<uint64,string> = Ok 32768UL
    square 16 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``32`` () =
    let expected: Result<uint64,string> = Ok 2147483648UL
    square 32 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``64`` () =
    let expected: Result<uint64,string> = Ok 9223372036854775808UL
    square 64 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Square 0 raises an exception`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square 0 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative square raises an exception`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square -1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Square greater than 64 raises an exception`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square 65 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Returns the total number of grains on the board`` () =
    let expected: Result<uint64,string> = Ok 18446744073709551615UL
    total |> should equal expected

