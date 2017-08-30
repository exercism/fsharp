module MatrixTest

open Xunit
open FsUnit.Xunit

open Matrix

[<Theory>]
[<InlineData("1", [| 1 |])>]
[<InlineData("4 7", [| 4; 7 |])>]
[<InlineData("1 2\n10 20", [| 1; 2 |])>]
[<InlineData("9 7 6\n8 6 5\n5 3 2", [| 9; 7; 6 |])>]
let ``Extract first row`` (input: string) expected =    
    let matrix = fromString input    
    rows matrix |> Array.head |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("5", [| 5 |])>]
[<InlineData("9 7", [| 9; 7 |])>]
[<InlineData("9 8 7\n19 18 17", [| 19; 18; 17 |])>]
[<InlineData("1 4 9\n16 25 36\n5 6 7", [| 5; 6; 7 |])>]
let ``Extract last row`` (input: string) expected =
    let matrix = fromString input
    rows matrix |> Array.last |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("55 44", [| 55 |])>]
[<InlineData("89 1903\n18 3", [| 89; 18 |])>]
[<InlineData("1 2 3\n4 5 6\n7 8 9\n8 7 6", [| 1; 4; 7; 8 |])>]
let ``Extract first column`` (input: string) expected =
    let matrix = fromString input
    cols matrix |> Array.head |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("28", [| 28 |])>]
[<InlineData("13\n16\n19", [| 13; 16; 19 |])>]
[<InlineData("289 21903 23\n218 23 21", [| 23; 21 |])>]
[<InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", [| 13; 16; 19; 16 |])>]
let ``Extract last column`` (input: string) expected =
    let matrix = fromString input
    cols matrix |> Array.last |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("28", 1)>]
[<InlineData("13\n16", 2)>]
[<InlineData("289 21903\n23 218\n23 21", 3)>]
[<InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 4)>]
let ``Number of rows`` (input: string) expected =
    let matrix = fromString input
    rows matrix |> Array.length |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData("28", 1)>]
[<InlineData("13 2\n16 3\n19 4", 2)>]
[<InlineData("289 21903\n23 218\n23 21", 2)>]
[<InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 3)>]
let ``Number of columns`` (input: string) expected =
    let matrix = fromString input
    cols matrix |> Array.length |> should equal expected