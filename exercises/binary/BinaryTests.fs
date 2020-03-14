// This file was created manually and its version is 1.0.0.

module BinaryTest

open FsUnit.Xunit
open Xunit

open Binary

[<Fact(Skip = "Remove to run test")>]
let ``Binary_0_is_decimal_0`` () =
    toDecimal "0" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Binary_1_is_decimal_1`` () =
    toDecimal "1" |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Binary_10_is_decimal_2`` () =
    toDecimal "10" |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Binary_11_is_decimal_3`` () =
    toDecimal "11" |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Binary_100_is_decimal_4`` () =
    toDecimal "100" |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Binary_1001_is_decimal_9`` () =
    toDecimal "1001" |> should equal 9

[<Fact(Skip = "Remove to run test")>]
let ``Binary_11010_is_decimal_26`` () =
    toDecimal "11010" |> should equal 26

[<Fact(Skip = "Remove to run test")>]
let ``Binary_10001101000_is_decimal_1128`` () =
    toDecimal "10001101000" |> should equal 1128

[<Fact(Skip = "Remove to run test")>]
let ``Binary_ignores_leading_zeros`` () =
    toDecimal "000011111" |> should equal 31

[<Fact(Skip = "Remove to run test")>]
let ``2_is_not_a_valid_binary_digit`` () =
    toDecimal "2" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A_number_containing_a_non_binary_digit_is_invalid`` () =
    toDecimal "01201" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A_number_with_trailing_non_binary_characters_is_invalid`` () =
    toDecimal "10nope" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A_number_with_leading_non_binary_characters_is_invalid`` () =
    toDecimal "nope10" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A_number_with_internal_non_binary_characters_is_invalid`` () =
    toDecimal "10nope10" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A_number_and_a_word_whitespace_separated_is_invalid`` () =
    toDecimal "001 nope" |> should equal 0

