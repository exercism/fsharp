// This file was auto-generated based on version 1.1.0 of the canonical data.

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
let ``All caps words`` () =
    abbreviate "PHP: Hypertext Preprocessor" |> should equal "PHP"

[<Fact(Skip = "Remove to run test")>]
let ``non acronym all caps word`` () =
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

[<Fact(Skip = "Remove to run test")>]
let ``Hyphenated`` () =
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

