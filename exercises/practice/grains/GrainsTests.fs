module GrainsTests

open FsUnit.Xunit
open Xunit

open Grains

[<Fact>]
let ``Grains on square 1`` () =
    let expected: Result<uint64,string> = Ok 1UL
    square 1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 2`` () =
    let expected: Result<uint64,string> = Ok 2UL
    square 2 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 3`` () =
    let expected: Result<uint64,string> = Ok 4UL
    square 3 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 4`` () =
    let expected: Result<uint64,string> = Ok 8UL
    square 4 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 16`` () =
    let expected: Result<uint64,string> = Ok 32768UL
    square 16 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 32`` () =
    let expected: Result<uint64,string> = Ok 2147483648UL
    square 32 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Grains on square 64`` () =
    let expected: Result<uint64,string> = Ok 9223372036854775808UL
    square 64 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Square 0 is invalid`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square 0 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Negative square is invalid`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square -1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Square greater than 64 is invalid`` () =
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    square 65 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Returns the total number of grains on the board`` () =
    let expected: Result<uint64,string> = Ok 18446744073709551615UL
    total |> should equal expected

