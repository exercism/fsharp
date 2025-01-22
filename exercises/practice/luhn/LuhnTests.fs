source("./luhn.R")
library(testthat)

let ``Single digit strings can not be valid`` () =
    expect_equal(valid "1", false)

let ``A single zero is invalid`` () =
    expect_equal(valid "0", false)

let ``A simple valid SIN that remains valid if reversed`` () =
    expect_equal(valid "059", true)

let ``A simple valid SIN that becomes invalid if reversed`` () =
    expect_equal(valid "59", true)

let ``A valid Canadian SIN`` () =
    expect_equal(valid "055 444 285", true)

let ``Invalid Canadian SIN`` () =
    expect_equal(valid "055 444 286", false)

let ``Invalid credit card`` () =
    expect_equal(valid "8273 1232 7352 0569", false)

let ``Invalid long number with an even remainder`` () =
    expect_equal(valid "1 2345 6789 1234 5678 9012", false)

let ``Invalid long number with a remainder divisible by 5`` () =
    expect_equal(valid "1 2345 6789 1234 5678 9013", false)

let ``Valid number with an even number of digits`` () =
    expect_equal(valid "095 245 88", true)

let ``Valid number with an odd number of spaces`` () =
    expect_equal(valid "234 567 891 234", true)

let ``Valid strings with a non-digit added at the end become invalid`` () =
    expect_equal(valid "059a", false)

let ``Valid strings with punctuation included become invalid`` () =
    expect_equal(valid "055-444-285", false)

let ``Valid strings with symbols included become invalid`` () =
    expect_equal(valid "055# 444$ 285", false)

let ``Single zero with space is invalid`` () =
    expect_equal(valid " 0", false)

let ``More than a single zero is valid`` () =
    expect_equal(valid "0000 0", true)

let ``Input digit 9 is correctly converted to output digit 9`` () =
    expect_equal(valid "091", true)

let ``Very long input is valid`` () =
    expect_equal(valid "9999999999 9999999999 9999999999 9999999999", true)

let ``Valid luhn with an odd number of digits and non zero first digit`` () =
    expect_equal(valid "109", true)

let ``Using ascii value for non-doubled non-digit isn't allowed`` () =
    expect_equal(valid "055b 444 285", false)

let ``Using ascii value for doubled non-digit isn't allowed`` () =
    expect_equal(valid ":9", false)

let ``Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed`` () =
    expect_equal(valid "59%59", false)

