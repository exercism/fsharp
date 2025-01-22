source("./change.R")
library(testthat)

let ``Change for 1 cent`` () =
    coins <- [1; 5; 10; 25]
    target <- 1
    expected <- Some [1]
    findFewestCoins coins target |> should equal expected

let ``Single coin change`` () =
    coins <- [1; 5; 10; 25; 100]
    target <- 25
    expected <- Some [25]
    findFewestCoins coins target |> should equal expected

let ``Multiple coin change`` () =
    coins <- [1; 5; 10; 25; 100]
    target <- 15
    expected <- Some [5; 10]
    findFewestCoins coins target |> should equal expected

let ``Change with Lilliputian Coins`` () =
    coins <- [1; 4; 15; 20; 50]
    target <- 23
    expected <- Some [4; 4; 15]
    findFewestCoins coins target |> should equal expected

let ``Change with Lower Elbonia Coins`` () =
    coins <- [1; 5; 10; 21; 25]
    target <- 63
    expected <- Some [21; 21; 21]
    findFewestCoins coins target |> should equal expected

let ``Large target values`` () =
    coins <- [1; 2; 5; 10; 20; 50; 100]
    target <- 999
    expected <- Some [2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]
    findFewestCoins coins target |> should equal expected

let ``Possible change without unit coins available`` () =
    coins <- [2; 5; 10; 20; 50]
    target <- 21
    expected <- Some [2; 2; 2; 5; 10]
    findFewestCoins coins target |> should equal expected

let ``Another possible change without unit coins available`` () =
    coins <- [4; 5]
    target <- 27
    expected <- Some [4; 4; 4; 5; 5; 5]
    findFewestCoins coins target |> should equal expected

let ``No coins make 0 change`` () =
    coins <- [1; 5; 10; 21; 25]
    target <- 0
    let expected: int list option = Some []
    findFewestCoins coins target |> should equal expected

let ``Error testing for change smaller than the smallest of coins`` () =
    coins <- [5; 10]
    target <- 3
    expected <- None
    findFewestCoins coins target |> should equal expected

let ``Error if no combination can add up to target`` () =
    coins <- [5; 10]
    target <- 94
    expected <- None
    findFewestCoins coins target |> should equal expected

let ``Cannot find negative change values`` () =
    coins <- [1; 2; 5]
    target <- -5
    expected <- None
    findFewestCoins coins target |> should equal expected

