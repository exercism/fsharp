source("./palindrome-products.R")
library(testthat)

let ``Find the smallest palindrome from single digit factors`` () =
    let expected: int option * (int * int) list = (Some 1, [(1, 1)])
    expect_equal(smallest 1 9, expected)

let ``Find the largest palindrome from single digit factors`` () =
    let expected: int option * (int * int) list = (Some 9, [(1, 9); (3, 3)])
    expect_equal(largest 1 9, expected)

let ``Find the smallest palindrome from double digit factors`` () =
    let expected: int option * (int * int) list = (Some 121, [(11, 11)])
    expect_equal(smallest 10 99, expected)

let ``Find the largest palindrome from double digit factors`` () =
    let expected: int option * (int * int) list = (Some 9009, [(91, 99)])
    expect_equal(largest 10 99, expected)

let ``Find the smallest palindrome from triple digit factors`` () =
    let expected: int option * (int * int) list = (Some 10201, [(101, 101)])
    expect_equal(smallest 100 999, expected)

let ``Find the largest palindrome from triple digit factors`` () =
    let expected: int option * (int * int) list = (Some 906609, [(913, 993)])
    expect_equal(largest 100 999, expected)

let ``Find the smallest palindrome from four digit factors`` () =
    let expected: int option * (int * int) list = (Some 1002001, [(1001, 1001)])
    expect_equal(smallest 1000 9999, expected)

let ``Find the largest palindrome from four digit factors`` () =
    let expected: int option * (int * int) list = (Some 99000099, [(9901, 9999)])
    expect_equal(largest 1000 9999, expected)

let ``Empty result for smallest if no palindrome in the range`` () =
    let expected: int option * (int * int) list = (None, [])
    expect_equal(smallest 1002 1003, expected)

let ``Empty result for largest if no palindrome in the range`` () =
    let expected: int option * (int * int) list = (None, [])
    expect_equal(largest 15 15, expected)

let ``Error result for smallest if min is more than max`` () =
    (fun () -> smallest 10000 1 |> ignore) |> should throw typeof<System.ArgumentException>

let ``Error result for largest if min is more than max`` () =
    (fun () -> largest 2 1 |> ignore) |> should throw typeof<System.ArgumentException>

