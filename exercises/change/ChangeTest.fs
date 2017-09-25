// This file was auto-generated based on version 1.1.0 of the canonical data.

module ChangeTest

open FsUnit.Xunit
open Xunit

open Change

[<Fact>]
let ``Single coin change`` () =
    let coins = [1; 5; 10; 25; 100]
    let expected = Some "[25]"
    let target = 25
    findFewestCoins let coins = [1; 5; 10; 25; 100] let target = 25 |> should equal let expected = Some "[25]"

[<Fact(Skip = "Remove to run test")>]
let ``Multiple coin change`` () =
    let coins = [1; 5; 10; 25; 100]
    let expected = Some "[5; 10]"
    let target = 15
    findFewestCoins let coins = [1; 5; 10; 25; 100] let target = 15 |> should equal let expected = Some "[5; 10]"

[<Fact(Skip = "Remove to run test")>]
let ``Change with lilliputian coins`` () =
    let coins = [1; 4; 15; 20; 50]
    let expected = Some "[4; 4; 15]"
    let target = 23
    findFewestCoins let coins = [1; 4; 15; 20; 50] let target = 23 |> should equal let expected = Some "[4; 4; 15]"

[<Fact(Skip = "Remove to run test")>]
let ``Change with lower elbonia coins`` () =
    let coins = [1; 5; 10; 21; 25]
    let expected = Some "[21; 21; 21]"
    let target = 63
    findFewestCoins let coins = [1; 5; 10; 21; 25] let target = 63 |> should equal let expected = Some "[21; 21; 21]"

[<Fact(Skip = "Remove to run test")>]
let ``Large target values`` () =
    let coins = [1; 2; 5; 10; 20; 50; 100]
    let expected = Some "[2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]"
    let target = 999
    findFewestCoins let coins = [1; 2; 5; 10; 20; 50; 100] let target = 999 |> should equal let expected = Some "[2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]"

[<Fact(Skip = "Remove to run test")>]
let ``Possible change without unit coins available`` () =
    let coins = [2; 5; 10; 20; 50]
    let expected = Some "[2; 2; 2; 5; 10]"
    let target = 21
    findFewestCoins let coins = [2; 5; 10; 20; 50] let target = 21 |> should equal let expected = Some "[2; 2; 2; 5; 10]"

[<Fact(Skip = "Remove to run test")>]
let ``Another possible change without unit coins available`` () =
    let coins = [4; 5]
    let expected = Some "[4; 4; 4; 5; 5; 5]"
    let target = 27
    findFewestCoins let coins = [4; 5] let target = 27 |> should equal let expected = Some "[4; 4; 4; 5; 5; 5]"

[<Fact(Skip = "Remove to run test")>]
let ``No coins make 0 change`` () =
    let coins = [1; 5; 10; 21; 25]
    let expected = Some "[]"
    let target = 0
    findFewestCoins let coins = [1; 5; 10; 21; 25] let target = 0 |> should equal let expected = Some "[]"

[<Fact(Skip = "Remove to run test")>]
let ``Error testing for change smaller than the smallest of coins`` () =
    let coins = [5; 10]
    let expected = None
    let target = 3
    findFewestCoins let coins = [5; 10] let target = 3 |> should equal let expected = None

[<Fact(Skip = "Remove to run test")>]
let ``Error if no combination can add up to target`` () =
    let coins = [5; 10]
    let expected = None
    let target = 94
    findFewestCoins let coins = [5; 10] let target = 94 |> should equal let expected = None

[<Fact(Skip = "Remove to run test")>]
let ``Cannot find negative change values`` () =
    let coins = [1; 2; 5]
    let expected = None
    let target = -5
    findFewestCoins let coins = [1; 2; 5] let target = -5 |> should equal let expected = None

