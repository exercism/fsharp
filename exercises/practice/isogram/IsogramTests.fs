source("./isogram.R")
library(testthat)

let ``Empty string`` () =
    expect_equal(isIsogram "", true)

let ``Isogram with only lower case characters`` () =
    expect_equal(isIsogram "isogram", true)

let ``Word with one duplicated character`` () =
    expect_equal(isIsogram "eleven", false)

let ``Word with one duplicated character from the end of the alphabet`` () =
    expect_equal(isIsogram "zzyzx", false)

let ``Longest reported english isogram`` () =
    expect_equal(isIsogram "subdermatoglyphic", true)

let ``Word with duplicated character in mixed case`` () =
    expect_equal(isIsogram "Alphabet", false)

let ``Word with duplicated character in mixed case, lowercase first`` () =
    expect_equal(isIsogram "alphAbet", false)

let ``Hypothetical isogrammic word with hyphen`` () =
    expect_equal(isIsogram "thumbscrew-japingly", true)

let ``Hypothetical word with duplicated character following hyphen`` () =
    expect_equal(isIsogram "thumbscrew-jappingly", false)

let ``Isogram with duplicated hyphen`` () =
    expect_equal(isIsogram "six-year-old", true)

let ``Made-up name that is an isogram`` () =
    expect_equal(isIsogram "Emily Jung Schwartzkopf", true)

let ``Duplicated character in the middle`` () =
    expect_equal(isIsogram "accentor", false)

let ``Same first and last characters`` () =
    expect_equal(isIsogram "angola", false)

let ``Word with duplicated character and with two hyphens`` () =
    expect_equal(isIsogram "up-to-date", false)

