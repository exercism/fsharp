// This file was auto-generated based on version 2.3.0 of the canonical data.

module AllYourBaseTest

open FsUnit.Xunit
open Xunit

open AllYourBase

[<Fact>]
let ``Single bit one to decimal`` () =
    let digits = [1]
    let inputBase = 2
    let outputBase = 10
    let expected = Some [1]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Binary to single decimal`` () =
    let digits = [1; 0; 1]
    let inputBase = 2
    let outputBase = 10
    let expected = Some [5]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single decimal to binary`` () =
    let digits = [5]
    let inputBase = 10
    let outputBase = 2
    let expected = Some [1; 0; 1]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Binary to multiple decimal`` () =
    let digits = [1; 0; 1; 0; 1; 0]
    let inputBase = 2
    let outputBase = 10
    let expected = Some [4; 2]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decimal to binary`` () =
    let digits = [4; 2]
    let inputBase = 10
    let outputBase = 2
    let expected = Some [1; 0; 1; 0; 1; 0]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Trinary to hexadecimal`` () =
    let digits = [1; 1; 2; 0]
    let inputBase = 3
    let outputBase = 16
    let expected = Some [2; 10]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Hexadecimal to trinary`` () =
    let digits = [2; 10]
    let inputBase = 16
    let outputBase = 3
    let expected = Some [1; 1; 2; 0]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``15-bit integer`` () =
    let digits = [3; 46; 60]
    let inputBase = 97
    let outputBase = 73
    let expected = Some [6; 10; 45]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Empty list`` () =
    let digits = []
    let inputBase = 2
    let outputBase = 10
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single zero`` () =
    let digits = [0]
    let inputBase = 10
    let outputBase = 2
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple zeros`` () =
    let digits = [0; 0; 0]
    let inputBase = 10
    let outputBase = 2
    let expected = Some [0]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Leading zeros`` () =
    let digits = [0; 6; 0]
    let inputBase = 7
    let outputBase = 10
    let expected = Some [4; 2]
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Input base is one`` () =
    let digits = [0]
    let inputBase = 1
    let outputBase = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Input base is zero`` () =
    let digits = []
    let inputBase = 0
    let outputBase = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Input base is negative`` () =
    let digits = [1]
    let inputBase = -2
    let outputBase = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative digit`` () =
    let digits = [1; -1; 1; 0; 1; 0]
    let inputBase = 2
    let outputBase = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid positive digit`` () =
    let digits = [1; 2; 1; 0; 1; 0]
    let inputBase = 2
    let outputBase = 10
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Output base is one`` () =
    let digits = [1; 0; 1; 0; 1; 0]
    let inputBase = 2
    let outputBase = 1
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Output base is zero`` () =
    let digits = [7]
    let inputBase = 10
    let outputBase = 0
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Output base is negative`` () =
    let digits = [1]
    let inputBase = 2
    let outputBase = -7
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Both bases are negative`` () =
    let digits = [1]
    let inputBase = -2
    let outputBase = -7
    let expected = None
    rebase digits inputBase outputBase |> should equal expected

