module AcronymTests

open FsUnit.Xunit
open Xunit

open Acronym

[<Fact>]
let ``Basic`` () =
    abbreviate "Portable Network Graphics" |> should equal "PNG"

[<Fact>]
let ``Lowercase words`` () =
    abbreviate "Ruby on Rails" |> should equal "ROR"

[<Fact>]
let ``Punctuation`` () =
    abbreviate "First In, First Out" |> should equal "FIFO"

[<Fact>]
let ``All caps word`` () =
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

[<Fact>]
let ``Punctuation without whitespace`` () =
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

[<Fact>]
let ``Very long abbreviation`` () =
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"

[<Fact>]
let ``Consecutive delimiters`` () =
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"

[<Fact>]
let ``Apostrophes`` () =
    abbreviate "Halley's Comet" |> should equal "HC"

[<Fact>]
let ``Underscore emphasis`` () =
    abbreviate "The Road _Not_ Taken" |> should equal "TRNT"
