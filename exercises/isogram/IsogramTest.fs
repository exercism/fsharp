// This file was auto-generated based on version 1.1.0 of the canonical data.

module IsogramTest

open FsUnit.Xunit
open Xunit

open Isogram

[<Fact>]
let ``empty string`` () =
    isIsogram "" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``isogram with only lower case characters`` () =
    isIsogram "isogram" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``word with one duplicated character`` () =
    isIsogram "eleven" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``longest reported english isogram`` () =
    isIsogram "subdermatoglyphic" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``word with duplicated character in mixed case`` () =
    isIsogram "Alphabet" |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``hypothetical isogrammic word with hyphen`` () =
    isIsogram "thumbscrew-japingly" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``isogram with duplicated non letter character`` () =
    isIsogram "Hjelmqvist-Gryb-Zock-Pfund-Wax" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``made-up name that is an isogram`` () =
    isIsogram "Emily Jung Schwartzkopf" |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``duplicated character in the middle`` () =
    isIsogram "accentor" |> should equal false

