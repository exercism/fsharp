source("./rotational-cipher.R")
library(testthat)

let ``Rotate a by 0, same output as input`` () =
    expect_equal(rotate 0 "a", "a")

let ``Rotate a by 1`` () =
    expect_equal(rotate 1 "a", "b")

let ``Rotate a by 26, same output as input`` () =
    expect_equal(rotate 26 "a", "a")

let ``Rotate m by 13`` () =
    expect_equal(rotate 13 "m", "z")

let ``Rotate n by 13 with wrap around alphabet`` () =
    expect_equal(rotate 13 "n", "a")

let ``Rotate capital letters`` () =
    expect_equal(rotate 5 "OMG", "TRL")

let ``Rotate spaces`` () =
    expect_equal(rotate 5 "O M G", "T R L")

let ``Rotate numbers`` () =
    expect_equal(rotate 4 "Testing 1 2 3 testing", "Xiwxmrk 1 2 3 xiwxmrk")

let ``Rotate punctuation`` () =
    expect_equal(rotate 21 "Let's eat, Grandma!", "Gzo'n zvo, Bmviyhv!")

let ``Rotate all letters`` () =
    expect_equal(rotate 13 "The quick brown fox jumps over the lazy dog.", "Gur dhvpx oebja sbk whzcf bire gur ynml qbt.")

