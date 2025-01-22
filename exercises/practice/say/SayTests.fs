source("./say.R")
library(testthat)

let ``Zero`` () =
    expect_equal(say 0L, (Some "zero"))

let ``One`` () =
    expect_equal(say 1L, (Some "one"))

let ``Fourteen`` () =
    expect_equal(say 14L, (Some "fourteen"))

let ``Twenty`` () =
    expect_equal(say 20L, (Some "twenty"))

let ``Twenty-two`` () =
    expect_equal(say 22L, (Some "twenty-two"))

let ``Thirty`` () =
    expect_equal(say 30L, (Some "thirty"))

let ``Ninety-nine`` () =
    expect_equal(say 99L, (Some "ninety-nine"))

let ``One hundred`` () =
    expect_equal(say 100L, (Some "one hundred"))

let ``One hundred twenty-three`` () =
    expect_equal(say 123L, (Some "one hundred twenty-three"))

let ``Two hundred`` () =
    expect_equal(say 200L, (Some "two hundred"))

let ``Nine hundred ninety-nine`` () =
    expect_equal(say 999L, (Some "nine hundred ninety-nine"))

let ``One thousand`` () =
    expect_equal(say 1000L, (Some "one thousand"))

let ``One thousand two hundred thirty-four`` () =
    expect_equal(say 1234L, (Some "one thousand two hundred thirty-four"))

let ``One million`` () =
    expect_equal(say 1000000L, (Some "one million"))

let ``One million two thousand three hundred forty-five`` () =
    expect_equal(say 1002345L, (Some "one million two thousand three hundred forty-five"))

let ``One billion`` () =
    expect_equal(say 1000000000L, (Some "one billion"))

let ``A big number`` () =
    expect_equal(say 987654321123L, (Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"))

let ``Numbers below zero are out of range`` () =
    expect_equal(say -1L, None)

let ``Numbers above 999,999,999,999 are out of range`` () =
    expect_equal(say 1000000000000L, None)

