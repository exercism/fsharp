source("./isbn-verifier.R")
library(testthat)

let ``Valid isbn`` () =
    expect_equal(isValid "3-598-21508-8", true)

let ``Invalid isbn check digit`` () =
    expect_equal(isValid "3-598-21508-9", false)

let ``Valid isbn with a check digit of 10`` () =
    expect_equal(isValid "3-598-21507-X", true)

let ``Check digit is a character other than X`` () =
    expect_equal(isValid "3-598-21507-A", false)

let ``Invalid check digit in isbn is not treated as zero`` () =
    expect_equal(isValid "4-598-21507-B", false)

let ``Invalid character in isbn is not treated as zero`` () =
    expect_equal(isValid "3-598-P1581-X", false)

let ``X is only valid as a check digit`` () =
    expect_equal(isValid "3-598-2X507-9", false)

let ``Valid isbn without separating dashes`` () =
    expect_equal(isValid "3598215088", true)

let ``Isbn without separating dashes and X as check digit`` () =
    expect_equal(isValid "359821507X", true)

let ``Isbn without check digit and dashes`` () =
    expect_equal(isValid "359821507", false)

let ``Too long isbn and no dashes`` () =
    expect_equal(isValid "3598215078X", false)

let ``Too short isbn`` () =
    expect_equal(isValid "00", false)

let ``Isbn without check digit`` () =
    expect_equal(isValid "3-598-21507", false)

let ``Check digit of X should not be used for 0`` () =
    expect_equal(isValid "3-598-21515-X", false)

let ``Empty isbn`` () =
    expect_equal(isValid "", false)

let ``Input is 9 characters`` () =
    expect_equal(isValid "134456729", false)

let ``Invalid characters are not ignored after checking length`` () =
    expect_equal(isValid "3132P34035", false)

let ``Invalid characters are not ignored before checking length`` () =
    expect_equal(isValid "3598P215088", false)

let ``Input is too long but contains a valid isbn`` () =
    expect_equal(isValid "98245726788", false)

