module SublistTest

open NUnit.Framework
open FsUnit

open Sublist

[<Test>]
let ``Empty equals empty`` () =
    sublist [] [] |> should equal Equal

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty is a sublist of anything`` () =
    sublist [] [1; 2; 3; 4] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Anything is a superlist of empty`` () =
    sublist [1; 2; 3; 4] [] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``1 is not 2`` () =
    sublist [1] [2] |> should equal Unequal

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compare larger equal lists`` () =
    let xs = List.replicate 1000 'x'
    sublist xs xs |> should equal Equal

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist at start`` () =
    sublist [1; 2; 3] [1; 2; 3; 4; 5] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist in middle`` () =
    sublist [4; 3; 2] [5; 4; 3; 2; 1] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist at end`` () =
    sublist [3; 4; 5] [1; 2; 3; 4; 5] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Partially matching sublist at start`` () =
    sublist [1; 1; 2] [1; 1; 1; 2] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist early in huge list`` () =
    sublist [3; 4; 5] [1 .. 1000000]  |> should equal Sublist
 
[<Test>]
[<Ignore("Remove to run test")>]
let ``Huge sublist not in huge list`` () =
    sublist [10 .. 1000001] [1 .. 1000000] |> should equal Unequal

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist at start`` () =
    sublist [1; 2; 3; 4; 5] [1; 2; 3] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist in middle`` () =
    sublist [5; 4; 3; 2; 1] [4; 3; 2] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist at end`` () =
    sublist [1; 2; 3; 4; 5] [3; 4; 5] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Partially matching superlist at start`` () =
    sublist [1; 1; 1; 2] [1; 1; 2] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist early in huge list`` () =
    sublist [1 .. 1000000] [3; 4; 5] |> should equal Superlist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recurring values sublist`` () =
    sublist [1; 2; 1; 2; 3] [1; 2; 3; 1; 2; 1; 2; 3; 2; 1] |> should equal Sublist

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recurring values unequal`` () =
    sublist [1; 2; 1; 2; 3] [1; 2; 3; 1; 2; 3; 2; 3; 2; 1] |> should equal Unequal