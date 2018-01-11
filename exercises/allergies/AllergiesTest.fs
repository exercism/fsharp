// This file was auto-generated based on version 1.1.0 of the canonical data.

module AllergiesTest

open FsUnit.Xunit
open Xunit

open Allergies

[<Fact>]
let ``No allergies means not allergic`` () =
    allergicTo 0 Allergen.Peanuts |> should equal false
    allergicTo 0 Allergen.Cats |> should equal false
    allergicTo 0 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Is allergic to eggs`` () =
    allergicTo 1 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs in addition to other stuff`` () =
    allergicTo 5 Allergen.Eggs |> should equal true
    allergicTo 5 Allergen.Shellfish |> should equal true
    allergicTo 5 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``No allergies at all`` () =
    list 0 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just eggs`` () =
    list 1 |> should equal [Allergen.Eggs]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just peanuts`` () =
    list 2 |> should equal [Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just strawberries`` () =
    list 8 |> should equal [Allergen.Strawberries]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs and peanuts`` () =
    list 3 |> should equal [Allergen.Eggs; Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to more than eggs but not peanuts`` () =
    list 5 |> should equal [Allergen.Eggs; Allergen.Shellfish]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to lots of stuff`` () =
    list 248 |> should equal [Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    list 255 |> should equal [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove to run test")>]
let ``Ignore non allergen score parts`` () =
    list 509 |> should equal [Allergen.Eggs; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

