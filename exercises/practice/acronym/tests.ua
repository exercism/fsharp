~ "SOLUTION" ~ Acronym

let ``Basic`` () =
    abbreviate "Portable Network Graphics" |> should equal "PNG"

let ``Lowercase words`` () =
    abbreviate "Ruby on Rails" |> should equal "ROR"

let ``Punctuation`` () =
    abbreviate "First In, First Out" |> should equal "FIFO"

let ``All caps word`` () =
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

let ``Punctuation without whitespace`` () =
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

let ``Very long abbreviation`` () =
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"

let ``Consecutive delimiters`` () =
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"

let ``Apostrophes`` () =
    abbreviate "Halley's Comet" |> should equal "HC"

let ``Underscore emphasis`` () =
    abbreviate "The Road _Not_ Taken" |> should equal "TRNT"

