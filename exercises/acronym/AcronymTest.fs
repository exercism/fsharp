module AcronymTest

open Xunit
open FsUnit.Xunit
open Acronym

[<Fact>]
let ``Empty string abbreviated to empty string`` () =
    acronym "" |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``Basic`` () =
    let phrase = "Portable Network Graphics"
    let expected = "PNG"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``Lowercase words`` () =
    let phrase = "Ruby on Rails"
    let expected = "ROR"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``Camel case`` () =
    let phrase = "HyperText Markup Language"
    let expected = "HTML"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``Punctuation`` () =
    let phrase = "First In, First Out"
    let expected = "FIFO"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``All-Caps words`` () =
    let phrase = "PHP: Hypertext Preprocessor"
    let expected = "PHP"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``Non-acronym all-caps word`` () =
    let phrase = "GNU Image Manipulation Program"
    let expected = "GIMP"
    let actual = acronym phrase
    expected |> should equal actual

[<Fact(Skip = "Remove to run test")>]
let ``Hyphenated`` () =
    let phrase = "Complementary metal-oxide semiconductor"
    let expected = "CMOS"
    let actual = acronym phrase
    expected |> should equal actual