module AcronymTests

open FsUnit.Xunit
open Xunit

open Acronym

[<Fact>]
let ``Basic`` () =
    abbreviate "Portable Network Graphics" |> should equal "PNG"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Lowercase words`` () =
    abbreviate "Ruby on Rails" |> should equal "ROR"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Punctuation`` () =
    abbreviate "First In, First Out" |> should equal "FIFO"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``All caps word`` () =
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Punctuation without whitespace`` () =
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Very long abbreviation`` () =
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Consecutive delimiters`` () =
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Apostrophes`` () =
    abbreviate "Halley's Comet" |> should equal "HC"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Underscore emphasis`` () =
    abbreviate "The Road _Not_ Taken" |> should equal "TRNT"

