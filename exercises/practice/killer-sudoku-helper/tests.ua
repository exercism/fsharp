module KillerSudokuHelperTests

open FsUnit.Xunit
open Xunit

open KillerSudokuHelper

[<Fact>]
let ``1`` () =
    combinations [] 1 1 |> should equal [[1]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``2`` () =
    combinations [] 1 2 |> should equal [[2]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``3`` () =
    combinations [] 1 3 |> should equal [[3]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``4`` () =
    combinations [] 1 4 |> should equal [[4]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``5`` () =
    combinations [] 1 5 |> should equal [[5]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``6`` () =
    combinations [] 1 6 |> should equal [[6]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``7`` () =
    combinations [] 1 7 |> should equal [[7]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``8`` () =
    combinations [] 1 8 |> should equal [[8]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``9`` () =
    combinations [] 1 9 |> should equal [[9]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cage with sum 45 contains all digits 1:9`` () =
    combinations [] 9 45 |> should equal [[1; 2; 3; 4; 5; 6; 7; 8; 9]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cage with only 1 possible combination`` () =
    combinations [] 3 7 |> should equal [[1; 2; 4]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cage with several combinations`` () =
    combinations [] 2 10 |> should equal [[1; 9]; [2; 8]; [3; 7]; [4; 6]]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cage with several combinations that is restricted`` () =
    combinations [1; 4] 2 10 |> should equal [[2; 8]; [3; 7]]

