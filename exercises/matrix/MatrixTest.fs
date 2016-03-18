module MatrixTest

open NUnit.Framework

open Matrix

[<TestCase("1", ExpectedResult = [| 1 |])>]
[<TestCase("4 7", ExpectedResult = [| 4; 7 |], Ignore = "Remove to run test case")>]
[<TestCase("1 2\n10 20", ExpectedResult = [| 1; 2 |], Ignore = "Remove to run test case")>]
[<TestCase("9 7 6\n8 6 5\n5 3 2", ExpectedResult = [| 9; 7; 6 |], Ignore = "Remove to run test case")>]
let ``Extract first row`` (input: string) =    
    let matrix = fromString input    
    rows matrix |> Array.head

[<TestCase("5", ExpectedResult = [| 5 |], Ignore = "Remove to run test case")>]
[<TestCase("9 7", ExpectedResult = [| 9; 7 |], Ignore = "Remove to run test case")>]
[<TestCase("9 8 7\n19 18 17", ExpectedResult = [| 19; 18; 17 |], Ignore = "Remove to run test case")>]
[<TestCase("1 4 9\n16 25 36\n5 6 7", ExpectedResult = [| 5; 6; 7 |], Ignore = "Remove to run test case")>]
let ``Extract last row`` (input: string) =
    let matrix = fromString input
    rows matrix |> Array.last

[<TestCase("55 44", ExpectedResult = [| 55 |], Ignore = "Remove to run test case")>]
[<TestCase("89 1903\n18 3", ExpectedResult = [| 89; 18 |], Ignore = "Remove to run test case")>]
[<TestCase("1 2 3\n4 5 6\n7 8 9\n8 7 6", ExpectedResult = [| 1; 4; 7; 8 |], Ignore = "Remove to run test case")>]
let ``Extract first column`` (input: string) =
    let matrix = fromString input
    cols matrix |> Array.head

[<TestCase("28", ExpectedResult = [| 28 |], Ignore = "Remove to run test case")>]
[<TestCase("13\n16\n19", ExpectedResult = [| 13; 16; 19 |], Ignore = "Remove to run test case")>]
[<TestCase("289 21903 23\n218 23 21", ExpectedResult = [| 23; 21 |], Ignore = "Remove to run test case")>]
[<TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = [| 13; 16; 19; 16 |], Ignore = "Remove to run test case")>]
let ``Extract last column`` (input: string) =
    let matrix = fromString input
    cols matrix |> Array.last

[<TestCase("28", ExpectedResult = 1, Ignore = "Remove to run test case")>]
[<TestCase("13\n16", ExpectedResult = 2, Ignore = "Remove to run test case")>]
[<TestCase("289 21903\n23 218\n23 21", ExpectedResult = 3, Ignore = "Remove to run test case")>]
[<TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = 4, Ignore = "Remove to run test case")>]
let ``Number of rows`` (input: string) =
    let matrix = fromString input
    rows matrix |> Array.length

[<TestCase("28", ExpectedResult = 1, Ignore = "Remove to run test case")>]
[<TestCase("13 2\n16 3\n19 4", ExpectedResult = 2, Ignore = "Remove to run test case")>]
[<TestCase("289 21903\n23 218\n23 21", ExpectedResult = 2, Ignore = "Remove to run test case")>]
[<TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = 3, Ignore = "Remove to run test case")>]
let ``Number of columns`` (input: string) =
    let matrix = fromString input
    cols matrix |> Array.length