// This file was auto-generated based on version 1.1.0 of the canonical data.

module PalindromeProductsTest

open FsUnit.Xunit
open Xunit

open PalindromeProducts

[<Fact>]
let ``Finds the smallest palindrome from single digit factors`` () =
    smallest 1 9 |> should equal (Some (1, [(1, 1)]))

[<Fact(Skip = "Remove to run test")>]
let ``Finds the largest palindrome from single digit factors`` () =
    largest 1 9 |> should equal (Some (9, [(1, 9); (3, 3)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find the smallest palindrome from double digit factors`` () =
    smallest 10 99 |> should equal (Some (121, [(11, 11)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find the largest palindrome from double digit factors`` () =
    largest 10 99 |> should equal (Some (9009, [(91, 99)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find smallest palindrome from triple digit factors`` () =
    smallest 100 999 |> should equal (Some (10201, [(101, 101)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find the largest palindrome from triple digit factors`` () =
    largest 100 999 |> should equal (Some (906609, [(913, 993)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find smallest palindrome from four digit factors`` () =
    smallest 1000 9999 |> should equal (Some (1002001, [(1001, 1001)]))

[<Fact(Skip = "Remove to run test")>]
let ``Find the largest palindrome from four digit factors`` () =
    largest 1000 9999 |> should equal (Some (99000099, [(9901, 9999)]))

[<Fact(Skip = "Remove to run test")>]
let ``Empty result for smallest if no palindrome in the range`` () =
    smallest 1002 1003 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Empty result for largest if no palindrome in the range`` () =
    largest 15 15 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Error result for smallest if min is more than max`` () =
    smallest 10000 1 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Error result for largest if min is more than max`` () =
    largest 2 1 |> should equal None

