// This file was auto-generated based on version 2.0.0 of the canonical data.

module DominoesTest

open FsUnit.Xunit
open Xunit

open Dominoes

[<Fact>]
let ``Empty input = empty output`` () =
    let input = []
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Singleton input = singleton output`` () =
    let input = [(1, 1)]
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Singleton that can't be chained`` () =
    let input = [(1, 2)]
    let expected = false
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Three elements`` () =
    let input = [(1, 2); (3, 1); (2, 3)]
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Can reverse dominoes`` () =
    let input = [(1, 2); (1, 3); (2, 3)]
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Can't be chained`` () =
    let input = [(1, 2); (4, 1); (2, 3)]
    let expected = false
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Disconnected - simple`` () =
    let input = [(1, 1); (2, 2)]
    let expected = false
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Disconnected - double loop`` () =
    let input = [(1, 2); (2, 1); (3, 4); (4, 3)]
    let expected = false
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Disconnected - single isolated`` () =
    let input = [(1, 2); (2, 3); (3, 1); (4, 4)]
    let expected = false
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Need backtrack`` () =
    let input = [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Separate loops`` () =
    let input = [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
    let expected = true
    canChain input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Nine elements`` () =
    let input = [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
    let expected = true
    canChain input |> should equal expected

