source("./run-length-encoding.R")
library(testthat)

let ``Encode empty string`` () =
    expect_equal(encode "", "")

let ``Encode single characters only are encoded without count`` () =
    expect_equal(encode "XYZ", "XYZ")

let ``Encode string with no single characters`` () =
    expect_equal(encode "AABBBCCCC", "2A3B4C")

let ``Encode single characters mixed with repeated characters`` () =
    expect_equal(encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB", "12WB12W3B24WB")

let ``Encode multiple whitespace mixed in string`` () =
    expect_equal(encode "  hsqq qww  ", "2 hs2q q2w2 ")

let ``Encode lowercase characters`` () =
    expect_equal(encode "aabbbcccc", "2a3b4c")

let ``Decode empty string`` () =
    expect_equal(decode "", "")

let ``Decode single characters only`` () =
    expect_equal(decode "XYZ", "XYZ")

let ``Decode string with no single characters`` () =
    expect_equal(decode "2A3B4C", "AABBBCCCC")

let ``Decode single characters with repeated characters`` () =
    expect_equal(decode "12WB12W3B24WB", "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB")

let ``Decode multiple whitespace mixed in string`` () =
    expect_equal(decode "2 hs2q q2w2 ", "  hsqq qww  ")

let ``Decode lowercase string`` () =
    expect_equal(decode "2a3b4c", "aabbbcccc")

let ``Encode followed by decode gives original string`` () =
    expect_equal("zzz ZZ  zZ" |> encode |> decode, "zzz ZZ  zZ")

