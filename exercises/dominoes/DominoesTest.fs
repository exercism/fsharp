module DominoesTest

open NUnit.Framework
open FsUnit

open Dominoes

[<Test>]
let ``Empty input = empty output`` () =
    let actual = []
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Singleton input = singleton output`` () =
    let actual = [(1, 1)]
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Singleton that can't be chained`` () =
    let actual = [(1, 2)]
    canChain actual |> should be false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three elements`` () =
    let actual = [(1, 2); (3, 1); (2, 3)]
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can reverse dominoes`` () =
    let actual = [(1, 2); (1, 3); (2, 3)]
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can't be chained`` () =
    let actual = [(1, 2); (4, 1); (2, 3)]
    canChain actual |> should be false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Disconnected - simple`` () =
    let actual = [(1, 1); (2, 2)]
    canChain actual |> should be false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Disconnected - double loop`` () =
    let actual = [(1, 2); (2, 1); (3, 4); (4, 3)]
    canChain actual |> should be false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Disconnected - single isolated`` () =
    let actual = [(1, 2); (2, 3); (3, 1); (4, 4)]
    canChain actual |> should be false

[<Test>]
[<Ignore("Remove to run test")>]
let ``Need backtrack`` () =
    let actual = [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Separate loops`` () =
    let actual = [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
    canChain actual |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Ten elements`` () =
    let actual = [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
    canChain actual |> should be true