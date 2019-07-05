// This file was auto-generated based on version 2.0.0 of the canonical data.

module AllergiesTest

open FsUnit.Xunit
open Xunit

open Allergies

[<Fact>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Eggs |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to eggs`` () =
    allergicTo 1 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs and something else`` () =
    allergicTo 3 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not eggs`` () =
    allergicTo 2 Allergen.Eggs |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Peanuts |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to peanuts`` () =
    allergicTo 2 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to peanuts and something else`` () =
    allergicTo 7 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not peanuts`` () =
    allergicTo 5 Allergen.Peanuts |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Shellfish |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to shellfish`` () =
    allergicTo 4 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to shellfish and something else`` () =
    allergicTo 14 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not shellfish`` () =
    allergicTo 10 Allergen.Shellfish |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to strawberries`` () =
    allergicTo 8 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to strawberries and something else`` () =
    allergicTo 28 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not strawberries`` () =
    allergicTo 20 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Tomatoes |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to tomatoes`` () =
    allergicTo 16 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to tomatoes and something else`` () =
    allergicTo 56 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not tomatoes`` () =
    allergicTo 40 Allergen.Tomatoes |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Chocolate |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to chocolate`` () =
    allergicTo 32 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to chocolate and something else`` () =
    allergicTo 112 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not chocolate`` () =
    allergicTo 80 Allergen.Chocolate |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Pollen |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to pollen`` () =
    allergicTo 64 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to pollen and something else`` () =
    allergicTo 224 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not pollen`` () =
    allergicTo 160 Allergen.Pollen |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Not allergic to anything`` () =
    allergicTo 0 Allergen.Cats |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic only to cats`` () =
    allergicTo 128 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to cats and something else`` () =
    allergicTo 192 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to something, but not cats`` () =
    allergicTo 64 Allergen.Cats |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergicTo 255 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``No allergies`` () =
    list 0 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Just eggs`` () =
    list 1 |> should equal [Allergen.Eggs]

[<Fact(Skip = "Remove to run test")>]
let ``Just peanuts`` () =
    list 2 |> should equal [Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``Just strawberries`` () =
    list 8 |> should equal [Allergen.Strawberries]

[<Fact(Skip = "Remove to run test")>]
let ``Eggs and peanuts`` () =
    list 3 |> should equal [Allergen.Eggs; Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``More than eggs but not peanuts`` () =
    list 5 |> should equal [Allergen.Eggs; Allergen.Shellfish]

[<Fact(Skip = "Remove to run test")>]
let ``Lots of stuff`` () =
    list 248 |> should equal [Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove to run test")>]
let ``Everything`` () =
    list 255 |> should equal [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove to run test")>]
let ``No allergen score parts`` () =
    list 509 |> should equal [Allergen.Eggs; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

