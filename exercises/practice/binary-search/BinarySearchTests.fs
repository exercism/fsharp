source("./binary-search.R")
library(testthat)

let ``Finds a value in an array with one element`` () =
    array <- [|6|]
    value <- 6
    expected <- Some 0
    find array value |> should equal expected

let ``Finds a value in the middle of an array`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 6
    expected <- Some 3
    find array value |> should equal expected

let ``Finds a value at the beginning of an array`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 1
    expected <- Some 0
    find array value |> should equal expected

let ``Finds a value at the end of an array`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 11
    expected <- Some 6
    find array value |> should equal expected

let ``Finds a value in an array of odd length`` () =
    array <- [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 634|]
    value <- 144
    expected <- Some 9
    find array value |> should equal expected

let ``Finds a value in an array of even length`` () =
    array <- [|1; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377|]
    value <- 21
    expected <- Some 5
    find array value |> should equal expected

let ``Identifies that a value is not included in the array`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 7
    expected <- None
    find array value |> should equal expected

let ``A value smaller than the array's smallest value is not found`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 0
    expected <- None
    find array value |> should equal expected

let ``A value larger than the array's largest value is not found`` () =
    array <- [|1; 3; 4; 6; 8; 9; 11|]
    value <- 13
    expected <- None
    find array value |> should equal expected

let ``Nothing is found in an empty array`` () =
    array <- [||]
    value <- 1
    expected <- None
    find array value |> should equal expected

let ``Nothing is found when the left and right bounds cross`` () =
    array <- [|1; 2|]
    value <- 0
    expected <- None
    find array value |> should equal expected

