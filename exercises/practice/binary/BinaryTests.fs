// This file was created manually and its version is 1.0.0.

source("./binary-test.R")
library(testthat)

let ``Binary_0_is_decimal_0`` () =
    expect_equal(toDecimal "0", 0)

let ``Binary_1_is_decimal_1`` () =
    expect_equal(toDecimal "1", 1)

let ``Binary_10_is_decimal_2`` () =
    expect_equal(toDecimal "10", 2)

let ``Binary_11_is_decimal_3`` () =
    expect_equal(toDecimal "11", 3)

let ``Binary_100_is_decimal_4`` () =
    expect_equal(toDecimal "100", 4)

let ``Binary_1001_is_decimal_9`` () =
    expect_equal(toDecimal "1001", 9)

let ``Binary_11010_is_decimal_26`` () =
    expect_equal(toDecimal "11010", 26)

let ``Binary_10001101000_is_decimal_1128`` () =
    expect_equal(toDecimal "10001101000", 1128)

let ``Binary_ignores_leading_zeros`` () =
    expect_equal(toDecimal "000011111", 31)

let ``2_is_not_a_valid_binary_digit`` () =
    expect_equal(toDecimal "2", 0)

let ``A_number_containing_a_non_binary_digit_is_invalid`` () =
    expect_equal(toDecimal "01201", 0)

let ``A_number_with_trailing_non_binary_characters_is_invalid`` () =
    expect_equal(toDecimal "10nope", 0)

let ``A_number_with_leading_non_binary_characters_is_invalid`` () =
    expect_equal(toDecimal "nope10", 0)

let ``A_number_with_internal_non_binary_characters_is_invalid`` () =
    expect_equal(toDecimal "10nope10", 0)

let ``A_number_and_a_word_whitespace_separated_is_invalid`` () =
    expect_equal(toDecimal "001 nope", 0)

