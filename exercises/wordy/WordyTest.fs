// This file was auto-generated based on version 1.1.0 of the canonical data.

module WordyTest

open FsUnit.Xunit
open Xunit

open Wordy

[<Fact>]
let ``Addition`` () =
    answer "What is 1 plus 1?" |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``More addition`` () =
    answer "What is 53 plus 2?" |> should equal (Some 55)

[<Fact(Skip = "Remove to run test")>]
let ``Addition with negative numbers`` () =
    answer "What is -1 plus -10?" |> should equal (Some -11)

[<Fact(Skip = "Remove to run test")>]
let ``Large addition`` () =
    answer "What is 123 plus 45678?" |> should equal (Some 45801)

[<Fact(Skip = "Remove to run test")>]
let ``Subtraction`` () =
    answer "What is 4 minus -12?" |> should equal (Some 16)

[<Fact(Skip = "Remove to run test")>]
let ``Multiplication`` () =
    answer "What is -3 multiplied by 25?" |> should equal (Some -75)

[<Fact(Skip = "Remove to run test")>]
let ``Division`` () =
    answer "What is 33 divided by -3?" |> should equal (Some -11)

[<Fact(Skip = "Remove to run test")>]
let ``Multiple additions`` () =
    answer "What is 1 plus 1 plus 1?" |> should equal (Some 3)

[<Fact(Skip = "Remove to run test")>]
let ``Addition and subtraction`` () =
    answer "What is 1 plus 5 minus -2?" |> should equal (Some 8)

[<Fact(Skip = "Remove to run test")>]
let ``Multiple subtraction`` () =
    answer "What is 20 minus 4 minus 13?" |> should equal (Some 3)

[<Fact(Skip = "Remove to run test")>]
let ``Subtraction then addition`` () =
    answer "What is 17 minus 6 plus 3?" |> should equal (Some 14)

[<Fact(Skip = "Remove to run test")>]
let ``Multiple multiplication`` () =
    answer "What is 2 multiplied by -2 multiplied by 3?" |> should equal (Some -12)

[<Fact(Skip = "Remove to run test")>]
let ``Addition and multiplication`` () =
    answer "What is -3 plus 7 multiplied by -2?" |> should equal (Some -8)

[<Fact(Skip = "Remove to run test")>]
let ``Multiple division`` () =
    answer "What is -12 divided by 2 divided by -3?" |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``Unknown operation`` () =
    answer "What is 52 cubed?" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Non math question`` () =
    answer "Who is the President of the United States?" |> should equal None

