// This file was auto-generated based on version 1.5.0 of the canonical data.

module AcronymTest

open FsUnit.Xunit
open Xunit

open Acronym

[<Fact>]
let ``Basic`` () =
    abbreviate "Portable Network Graphics" |> should equal "PNG"

[<Fact(Skip = "Remove to run test")>]
let ``Lowercase words`` () =
    abbreviate "Ruby on Rails" |> should equal "ROR"

[<Fact(Skip = "Remove to run test")>]
let ``Punctuation`` () =
    abbreviate "First In, First Out" |> should equal "FIFO"

[<Fact(Skip = "Remove to run test")>]
let ``All caps word`` () =
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

[<Fact(Skip = "Remove to run test")>]
let ``Punctuation without whitespace`` () =
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

[<Fact(Skip = "Remove to run test")>]
let ``Very long abbreviation`` () =
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"

[<Fact(Skip = "Remove to run test")>]
let ``Consecutive delimiters`` () =
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"

