module AllYourBaseTest

open NUnit.Framework
open FsUnit

open AllYourBase

[<Test>]
let ``Single bit one to decimal`` () =
    let inputBase = 2
    let inputDigits = [1]
    let outputBase = 10
    let outputDigits = Some [1]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Binary to single decimal`` () =
    let inputBase = 2
    let inputDigits = [1; 0; 1]
    let outputBase = 10
    let outputDigits = Some [5]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Single decimal to binary`` () =
    let inputBase = 10
    let inputDigits = [5]
    let outputBase = 2
    let outputDigits = Some [1; 0; 1]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Binary to multiple decimal`` () =
    let inputBase = 2
    let inputDigits = [1; 0; 1; 0; 1; 0]
    let outputBase = 10
    let outputDigits = Some [4; 2]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Decimal to binary`` () =
    let inputBase = 10
    let inputDigits = [4; 2]
    let outputBase = 2
    let outputDigits = Some [1; 0; 1; 0; 1; 0]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Trinary to hexadecimal`` () =
    let inputBase = 3
    let inputDigits = [1; 1; 2; 0]
    let outputBase = 16
    let outputDigits = Some [2; 10]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Hexadecimal to trinary`` () =
    let inputBase = 16
    let inputDigits = [2; 10]
    let outputBase = 3
    let outputDigits = Some [1; 1; 2; 0]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``15-bit integer`` () =
    let inputBase = 97
    let inputDigits = [3; 46; 60]
    let outputBase = 73
    let outputDigits = Some [6; 10; 45]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty list`` () =
    let inputBase = 2
    let inputDigits = []
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Single zero`` () =
    let inputBase = 10
    let inputDigits = [0]
    let outputBase = 2
    let outputDigits = Some [0]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple zeros`` () =
    let inputBase = 10
    let inputDigits = [0; 0; 0]
    let outputBase = 2
    let outputDigits = Some [0]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Leading zeros`` () =
    let inputBase = 7
    let inputDigits = [0; 6; 0]
    let outputBase = 10
    let outputDigits = Some [4; 2]
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Negative digit`` () =
    let inputBase = 2
    let inputDigits = [1; -1; 1; 0; 1; 0]
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Invalid positive digit`` () =
    let inputBase = 2
    let inputDigits = [1; 2; 1; 0; 1; 0]
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``First base is one`` () =
    let inputBase = 1
    let inputDigits = []
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second base is one`` () =
    let inputBase = 2
    let inputDigits = [1; 0; 1; 0; 1; 0]
    let outputBase = 1
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``First base is zero`` () =
    let inputBase = 0
    let inputDigits = []
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second base is zero`` () =
    let inputBase = 10
    let inputDigits = [7]
    let outputBase = 0
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``First base is negative`` () =
    let inputBase = -2
    let inputDigits = [1]
    let outputBase = 10
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second base is negative`` () =
    let inputBase = 2
    let inputDigits = [1]
    let outputBase = -7
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits

[<Test>]
[<Ignore("Remove to run test")>]
let ``Both bases are negative`` () =
    let inputBase = -2
    let inputDigits = [1]
    let outputBase = -7
    let outputDigits = None
    rebase inputBase inputDigits outputBase |> should equal outputDigits