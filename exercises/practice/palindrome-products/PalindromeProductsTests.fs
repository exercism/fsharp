module PalindromeProductsTests

open FsUnit.Xunit
open Xunit

open PalindromeProducts

[<Fact>]
let ``Find the smallest palindrome from single digit factors`` () =
    let expected: int option * (int * int) list = (Some 1, [(1, 1)])
    smallest 1 9 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the largest palindrome from single digit factors`` () =
    let expected: int option * (int * int) list = (Some 9, [(1, 9); (3, 3)])
    largest 1 9 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the smallest palindrome from double digit factors`` () =
    let expected: int option * (int * int) list = (Some 121, [(11, 11)])
    smallest 10 99 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the largest palindrome from double digit factors`` () =
    let expected: int option * (int * int) list = (Some 9009, [(91, 99)])
    largest 10 99 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the smallest palindrome from triple digit factors`` () =
    let expected: int option * (int * int) list = (Some 10201, [(101, 101)])
    smallest 100 999 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the largest palindrome from triple digit factors`` () =
    let expected: int option * (int * int) list = (Some 906609, [(913, 993)])
    largest 100 999 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the smallest palindrome from four digit factors`` () =
    let expected: int option * (int * int) list = (Some 1002001, [(1001, 1001)])
    smallest 1000 9999 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Find the largest palindrome from four digit factors`` () =
    let expected: int option * (int * int) list = (Some 99000099, [(9901, 9999)])
    largest 1000 9999 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Empty result for smallest if no palindrome in the range`` () =
    let expected: int option * (int * int) list = (None, [])
    smallest 1002 1003 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Empty result for largest if no palindrome in the range`` () =
    let expected: int option * (int * int) list = (None, [])
    largest 15 15 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Error result for smallest if min is more than max`` () =
    (fun () -> smallest 10000 1 |> ignore) |> should throw typeof<System.ArgumentException>

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Error result for largest if min is more than max`` () =
    (fun () -> largest 2 1 |> ignore) |> should throw typeof<System.ArgumentException>

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Smallest product does not use the smallest factor`` () =
    let expected: int option * (int * int) list = (Some 10988901, [(3297, 3333)])
    smallest 3215 4000 |> should equal expected

