source("./all-your-base.R")
library(testthat)

let ``Single bit one to decimal`` () =
    digits <- [1]
    inputBase <- 2
    outputBase <- 10
    expected <- Some [1]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Binary to single decimal`` () =
    digits <- [1; 0; 1]
    inputBase <- 2
    outputBase <- 10
    expected <- Some [5]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Single decimal to binary`` () =
    digits <- [5]
    inputBase <- 10
    outputBase <- 2
    expected <- Some [1; 0; 1]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Binary to multiple decimal`` () =
    digits <- [1; 0; 1; 0; 1; 0]
    inputBase <- 2
    outputBase <- 10
    expected <- Some [4; 2]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Decimal to binary`` () =
    digits <- [4; 2]
    inputBase <- 10
    outputBase <- 2
    expected <- Some [1; 0; 1; 0; 1; 0]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Trinary to hexadecimal`` () =
    digits <- [1; 1; 2; 0]
    inputBase <- 3
    outputBase <- 16
    expected <- Some [2; 10]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Hexadecimal to trinary`` () =
    digits <- [2; 10]
    inputBase <- 16
    outputBase <- 3
    expected <- Some [1; 1; 2; 0]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``15-bit integer`` () =
    digits <- [3; 46; 60]
    inputBase <- 97
    outputBase <- 73
    expected <- Some [6; 10; 45]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Empty list`` () =
    digits <- []
    inputBase <- 2
    outputBase <- 10
    expected <- Some [0]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Single zero`` () =
    digits <- [0]
    inputBase <- 10
    outputBase <- 2
    expected <- Some [0]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Multiple zeros`` () =
    digits <- [0; 0; 0]
    inputBase <- 10
    outputBase <- 2
    expected <- Some [0]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Leading zeros`` () =
    digits <- [0; 6; 0]
    inputBase <- 7
    outputBase <- 10
    expected <- Some [4; 2]
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Input base is one`` () =
    digits <- [0]
    inputBase <- 1
    outputBase <- 10
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Input base is zero`` () =
    digits <- []
    inputBase <- 0
    outputBase <- 10
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Input base is negative`` () =
    digits <- [1]
    inputBase <- -2
    outputBase <- 10
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Negative digit`` () =
    digits <- [1; -1; 1; 0; 1; 0]
    inputBase <- 2
    outputBase <- 10
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Invalid positive digit`` () =
    digits <- [1; 2; 1; 0; 1; 0]
    inputBase <- 2
    outputBase <- 10
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Output base is one`` () =
    digits <- [1; 0; 1; 0; 1; 0]
    inputBase <- 2
    outputBase <- 1
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Output base is zero`` () =
    digits <- [7]
    inputBase <- 10
    outputBase <- 0
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Output base is negative`` () =
    digits <- [1]
    inputBase <- 2
    outputBase <- -7
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

let ``Both bases are negative`` () =
    digits <- [1]
    inputBase <- -2
    outputBase <- -7
    expected <- None
    expect_equal(rebase digits inputBase outputBase, expected)

