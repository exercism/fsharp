// This file was auto-generated based on version 1.0.0 of the canonical data.

module MatrixTest

open FsUnit.Xunit
open Xunit

open Matrix

[<Fact>]
let ``Extract row from one number matrix`` () =
    row 0 "1" |> should equal [1]

[<Fact(Skip = "Remove to run test")>]
let ``Can extract row`` () =
    row 1 "1 2\n3 4" |> should equal [3; 4]

[<Fact(Skip = "Remove to run test")>]
let ``Extract row where numbers have different widths`` () =
    row 1 "1 2\n10 20" |> should equal [10; 20]

[<Fact(Skip = "Remove to run test")>]
let ``Can extract row from non-square matrix`` () =
    row 2 "1 2 3\n4 5 6\n7 8 9\n8 7 6" |> should equal [7; 8; 9]

[<Fact(Skip = "Remove to run test")>]
let ``Extract column from one number matrix`` () =
    column 0 "1" |> should equal [1]

[<Fact(Skip = "Remove to run test")>]
let ``Can extract column`` () =
    column 2 "1 2 3\n4 5 6\n7 8 9" |> should equal [3; 6; 9]

[<Fact(Skip = "Remove to run test")>]
let ``Can extract column from non-square matrix`` () =
    column 2 "1 2 3\n4 5 6\n7 8 9\n8 7 6" |> should equal [3; 6; 9; 6]

[<Fact(Skip = "Remove to run test")>]
let ``Extract column where numbers have different widths`` () =
    column 1 "89 1903 3\n18 3 1\n9 4 800" |> should equal [1903; 3; 4]

