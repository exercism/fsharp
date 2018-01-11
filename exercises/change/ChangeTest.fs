// This file was auto-generated based on version 1.2.0 of the canonical data.

module ChangeTest

open FsUnit.Xunit
open Xunit

open Change

[<Fact>]
let ``Single coin change`` () =
    let coins = [1; 5; 10; 25; 100]
    let target = 25
    let expected = Some [25]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple coin change`` () =
    let coins = [1; 5; 10; 25; 100]
    let target = 15
    let expected = Some [5; 10]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Change with Lilliputian Coins`` () =
    let coins = [1; 4; 15; 20; 50]
    let target = 23
    let expected = Some [4; 4; 15]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Change with Lower Elbonia Coins`` () =
    let coins = [1; 5; 10; 21; 25]
    let target = 63
    let expected = Some [21; 21; 21]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Large target values`` () =
    let coins = [1; 2; 5; 10; 20; 50; 100]
    let target = 999
    let expected = Some [2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Possible change without unit coins available`` () =
    let coins = [2; 5; 10; 20; 50]
    let target = 21
    let expected = Some [2; 2; 2; 5; 10]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Another possible change without unit coins available`` () =
    let coins = [4; 5]
    let target = 27
    let expected = Some [4; 4; 4; 5; 5; 5]
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``No coins make 0 change`` () =
    let coins = [1; 5; 10; 21; 25]
    let target = 0
    let expected: int list option = Some []
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Error testing for change smaller than the smallest of coins`` () =
    let coins = [5; 10]
    let target = 3
    let expected = None
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Error if no combination can add up to target`` () =
    let coins = [5; 10]
    let target = 94
    let expected = None
    findFewestCoins coins target |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cannot find negative change values`` () =
    let coins = [1; 2; 5]
    let target = -5
    let expected = None
    findFewestCoins coins target |> should equal expected

