source("./roman-numerals.R")
library(testthat)

let ``1 is I`` () =
    expect_equal(roman 1, "I")

let ``2 is II`` () =
    expect_equal(roman 2, "II")

let ``3 is III`` () =
    expect_equal(roman 3, "III")

let ``4 is IV`` () =
    expect_equal(roman 4, "IV")

let ``5 is V`` () =
    expect_equal(roman 5, "V")

let ``6 is VI`` () =
    expect_equal(roman 6, "VI")

let ``9 is IX`` () =
    expect_equal(roman 9, "IX")

let ``16 is XVI`` () =
    expect_equal(roman 16, "XVI")

let ``27 is XXVII`` () =
    expect_equal(roman 27, "XXVII")

let ``48 is XLVIII`` () =
    expect_equal(roman 48, "XLVIII")

let ``49 is XLIX`` () =
    expect_equal(roman 49, "XLIX")

let ``59 is LIX`` () =
    expect_equal(roman 59, "LIX")

let ``66 is LXVI`` () =
    expect_equal(roman 66, "LXVI")

let ``93 is XCIII`` () =
    expect_equal(roman 93, "XCIII")

let ``141 is CXLI`` () =
    expect_equal(roman 141, "CXLI")

let ``163 is CLXIII`` () =
    expect_equal(roman 163, "CLXIII")

let ``166 is CLXVI`` () =
    expect_equal(roman 166, "CLXVI")

let ``402 is CDII`` () =
    expect_equal(roman 402, "CDII")

let ``575 is DLXXV`` () =
    expect_equal(roman 575, "DLXXV")

let ``666 is DCLXVI`` () =
    expect_equal(roman 666, "DCLXVI")

let ``911 is CMXI`` () =
    expect_equal(roman 911, "CMXI")

let ``1024 is MXXIV`` () =
    expect_equal(roman 1024, "MXXIV")

let ``1666 is MDCLXVI`` () =
    expect_equal(roman 1666, "MDCLXVI")

let ``3000 is MMM`` () =
    expect_equal(roman 3000, "MMM")

let ``3001 is MMMI`` () =
    expect_equal(roman 3001, "MMMI")

let ``3999 is MMMCMXCIX`` () =
    expect_equal(roman 3999, "MMMCMXCIX")

