source("./list-ops.R")
library(testthat)

let ``append empty lists`` () =
    append [] [] |> should be Empty

let ``append list to empty list`` () =
    expect_equal(append [] [1; 2; 3; 4], [1; 2; 3; 4])

let ``append empty list to list`` () =
    expect_equal(append [1; 2; 3; 4] [], [1; 2; 3; 4])

let ``append non-empty lists`` () =
    expect_equal(append [1; 2] [2; 3; 4; 5], [1; 2; 2; 3; 4; 5])

let ``concat empty list`` () =
    concat [] |> should be Empty

let ``concat list of lists`` () =
    expect_equal(concat [[1; 2]; [3]; []; [4; 5; 6]], [1; 2; 3; 4; 5; 6])

let ``concat list of nested lists`` () =
    expect_equal(concat [[[1]; [2]]; [[3]]; [[]]; [[4; 5; 6]]], [[1]; [2]; [3]; []; [4; 5; 6]])

let ``filter empty list`` () =
    filter (fun acc -> acc % 2 = 1) [] |> should be Empty

let ``filter non-empty list`` () =
    expect_equal(filter (fun acc -> acc % 2 = 1) [1; 2; 3; 5], [1; 3; 5])

let ``length empty list`` () =
    expect_equal(length [], 0)

let ``length non-empty list`` () =
    expect_equal(length [1; 2; 3; 4], 4)

let ``map empty list`` () =
    map (fun acc -> acc + 1) [] |> should be Empty

let ``map non-empty list`` () =
    expect_equal(map (fun acc -> acc + 1) [1; 3; 5; 7], [2; 4; 6; 8])

let ``foldl empty list`` () =
    expect_equal(foldl (fun acc el -> el * acc) 2 [], 2)

let ``foldl direction independent function applied to non-empty list`` () =
    expect_equal(foldl (fun acc el -> el + acc) 5 [1; 2; 3; 4], 15)

let ``foldr empty list`` () =
    expect_equal(foldr (fun acc el -> el * acc) 2 [], 2)

let ``foldr direction independent function applied to non-empty list`` () =
    expect_equal(foldr (fun acc el -> el + acc) 5 [1; 2; 3; 4], 15)

let ``reverse empty list`` () =
    reverse [] |> should be Empty

let ``reverse non-empty list`` () =
    expect_equal(reverse [1; 3; 5; 7], [7; 5; 3; 1])

let ``reverse list of lists is not flattened`` () =
    expect_equal(reverse [[1; 2]; [3]; []; [4; 5; 6]], [[4; 5; 6]; []; [3]; [1; 2]])

