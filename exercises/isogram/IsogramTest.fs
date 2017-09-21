// This file was auto-generated based on version 1.1.0 of the canonical data.

module IsogramTest

open FsUnit.Xunit
open Xunit

open Isogram

[<Fact>]
let ``Empty string`` () =
    isIsogram "" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isogram with only lower case characters`` () =
    isIsogram "isogram" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Word with one duplicated character`` () =
    isIsogram "eleven" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Longest reported english isogram`` () =
    isIsogram "subdermatoglyphic" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Word with duplicated character in mixed case`` () =
    isIsogram "Alphabet" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Hypothetical isogrammic word with hyphen`` () =
    isIsogram "thumbscrew-japingly" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isogram with duplicated non letter character`` () =
    isIsogram "Hjelmqvist-Gryb-Zock-Pfund-Wax" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``made up name that is an isogram`` () =
    isIsogram "Emily Jung Schwartzkopf" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Duplicated character in the middle`` () =
    isIsogram "accentor" |> should equal false

