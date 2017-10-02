// This file was auto-generated based on version 1.1.0 of the canonical data.

module AllYourBaseTest

open FsUnit.Xunit
open Xunit

open AllYourBase

[<Fact>]
let ``Single bit one to decimal`` () =
    let expected = Some [1]
    let inputBase = 2
    let inputDigits = [1]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Binary to single decimal`` () =
    let expected = Some [5]
    let inputBase = 2
    let inputDigits = [1; 0; 1]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single decimal to binary`` () =
    let expected = Some [1; 0; 1]
    let inputBase = 10
    let inputDigits = [5]
    let outputBase = 2
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Binary to multiple decimal`` () =
    let expected = Some [4; 2]
    let inputBase = 2
    let inputDigits = [1; 0; 1; 0; 1; 0]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decimal to binary`` () =
    let expected = Some [1; 0; 1; 0; 1; 0]
    let inputBase = 10
    let inputDigits = [4; 2]
    let outputBase = 2
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Trinary to hexadecimal`` () =
    let expected = Some [2; 10]
    let inputBase = 3
    let inputDigits = [1; 1; 2; 0]
    let outputBase = 16
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Hexadecimal to trinary`` () =
    let expected = Some [1; 1; 2; 0]
    let inputBase = 16
    let inputDigits = [2; 10]
    let outputBase = 3
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``15-bit integer`` () =
    let expected = Some [6; 10; 45]
    let inputBase = 97
    let inputDigits = [3; 46; 60]
    let outputBase = 73
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Empty list`` () =
    let expected = None
    let inputBase = 2
    let inputDigits = []
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single zero`` () =
    let expected = None
    let inputBase = 10
    let inputDigits = [0]
    let outputBase = 2
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple zeros`` () =
    let expected = None
    let inputBase = 10
    let inputDigits = [0; 0; 0]
    let outputBase = 2
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Leading zeros`` () =
    let expected = None
    let inputBase = 7
    let inputDigits = [0; 6; 0]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``First base is one`` () =
    let expected = None
    let inputBase = 1
    let inputDigits = []
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``First base is zero`` () =
    let expected = None
    let inputBase = 0
    let inputDigits = []
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``First base is negative`` () =
    let expected = None
    let inputBase = -2
    let inputDigits = [1]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative digit`` () =
    let expected = None
    let inputBase = 2
    let inputDigits = [1; -1; 1; 0; 1; 0]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid positive digit`` () =
    let expected = None
    let inputBase = 2
    let inputDigits = [1; 2; 1; 0; 1; 0]
    let outputBase = 10
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Second base is one`` () =
    let expected = None
    let inputBase = 2
    let inputDigits = [1; 0; 1; 0; 1; 0]
    let outputBase = 1
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Second base is zero`` () =
    let expected = None
    let inputBase = 10
    let inputDigits = [7]
    let outputBase = 0
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Second base is negative`` () =
    let expected = None
    let inputBase = 2
    let inputDigits = [1]
    let outputBase = -7
    rebase inputBase inputDigits outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Both bases are negative`` () =
    let expected = None
    let inputBase = -2
    let inputDigits = [1]
    let outputBase = -7
    rebase inputBase inputDigits outputBase |> should equal expected

