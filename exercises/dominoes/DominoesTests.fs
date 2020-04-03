// This file was auto-generated based on version 2.1.0 of the canonical data.

module DominoesTests

open FsUnit.Xunit
open Xunit

open Dominoes

[<Fact>]
let ``Empty input = empty output`` () =
    let dominoes = []
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Singleton input = singleton output`` () =
    let dominoes = [(1, 1)]
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Singleton that can't be chained`` () =
    let dominoes = [(1, 2)]
    canChain dominoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Three elements`` () =
    let dominoes = [(1, 2); (3, 1); (2, 3)]
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Can reverse dominoes`` () =
    let dominoes = [(1, 2); (1, 3); (2, 3)]
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Can't be chained`` () =
    let dominoes = [(1, 2); (4, 1); (2, 3)]
    canChain dominoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Disconnected - simple`` () =
    let dominoes = [(1, 1); (2, 2)]
    canChain dominoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Disconnected - double loop`` () =
    let dominoes = [(1, 2); (2, 1); (3, 4); (4, 3)]
    canChain dominoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Disconnected - single isolated`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (4, 4)]
    canChain dominoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Need backtrack`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Separate loops`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
    canChain dominoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Nine elements`` () =
    let dominoes = [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
    canChain dominoes |> should equal true

