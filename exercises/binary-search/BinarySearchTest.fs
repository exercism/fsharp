// This file was auto-generated based on version 1.2.0 of the canonical data.

module BinarySearchTest

open FsUnit.Xunit
open Xunit

open BinarySearch

[<Fact>]
let ``Finds a value in an array with one element`` () =
    let array = [|6|]
    let value = 6
    let expected = Some 0
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Finds a value in the middle of an array`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 6
    let expected = Some 3
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Finds a value at the beginning of an array`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 1
    let expected = Some 0
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Finds a value at the end of an array`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 11
    let expected = Some 6
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Finds a value in an array of odd length`` () =
    let array = [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 634|]
    let value = 144
    let expected = Some 9
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Finds a value in an array of even length`` () =
    let array = [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377|]
    let value = 21
    let expected = Some 5
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Identifies that a value is not included in the array`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 7
    let expected = None
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``A value smaller than the array's smallest value is not included`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 0
    let expected = None
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``A value larger than the array's largest value is not included`` () =
    let array = [|1; 3; 4; 6; 8; 9; 11|]
    let value = 13
    let expected = None
    find array value |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Nothing is included in an empty array`` () =
    let array = [||]
    let value = 1
    let expected = None
    find array value |> should equal expected

