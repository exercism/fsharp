source("./pascals-triangle.R")
library(testthat)

let ``Zero rows`` () =
    let expected: int list list = []
    expect_equal(rows 0, expected)

let ``Single row`` () =
    expected <- [[1]]
    expect_equal(rows 1, expected)

let ``Two rows`` () =
    expected <- 
        [ [1];
          [1; 1] ]
    expect_equal(rows 2, expected)

let ``Three rows`` () =
    expected <- 
        [ [1];
          [1; 1];
          [1; 2; 1] ]
    expect_equal(rows 3, expected)

let ``Four rows`` () =
    expected <- 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1] ]
    expect_equal(rows 4, expected)

let ``Five rows`` () =
    expected <- 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1] ]
    expect_equal(rows 5, expected)

let ``Six rows`` () =
    expected <- 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1];
          [1; 5; 10; 10; 5; 1] ]
    expect_equal(rows 6, expected)

let ``Ten rows`` () =
    expected <- 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1];
          [1; 5; 10; 10; 5; 1];
          [1; 6; 15; 20; 15; 6; 1];
          [1; 7; 21; 35; 35; 21; 7; 1];
          [1; 8; 28; 56; 70; 56; 28; 8; 1];
          [1; 9; 36; 84; 126; 126; 84; 36; 9; 1] ]
    expect_equal(rows 10, expected)

