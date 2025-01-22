source("./acronym.R")
library(testthat)

let ``Basic`` () =
    expect_equal(abbreviate "Portable Network Graphics", "PNG")

let ``Lowercase words`` () =
    expect_equal(abbreviate "Ruby on Rails", "ROR")

let ``Punctuation`` () =
    expect_equal(abbreviate "First In, First Out", "FIFO")

let ``All caps word`` () =
    expect_equal(abbreviate "GNU Image Manipulation Program", "GIMP")

let ``Punctuation without whitespace`` () =
    expect_equal(abbreviate "Complementary metal-oxide semiconductor", "CMOS")

let ``Very long abbreviation`` () =
    expect_equal(abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me", "ROTFLSHTMDCOALM")

let ``Consecutive delimiters`` () =
    expect_equal(abbreviate "Something - I made up from thin air", "SIMUFTA")

let ``Apostrophes`` () =
    expect_equal(abbreviate "Halley's Comet", "HC")

let ``Underscore emphasis`` () =
    expect_equal(abbreviate "The Road _Not_ Taken", "TRNT")

