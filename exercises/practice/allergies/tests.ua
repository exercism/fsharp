module AllergiesTests

open FsUnit.Xunit
open Xunit

open Allergies

[<Fact>]
let ``Testing for eggs allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Eggs |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for eggs allergy - allergic only to eggs`` () =
    allergicTo 1 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for eggs allergy - allergic to eggs and something else`` () =
    allergicTo 3 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for eggs allergy - allergic to something, but not eggs`` () =
    allergicTo 2 Allergen.Eggs |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for eggs allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Eggs |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for peanuts allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Peanuts |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for peanuts allergy - allergic only to peanuts`` () =
    allergicTo 2 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for peanuts allergy - allergic to peanuts and something else`` () =
    allergicTo 7 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for peanuts allergy - allergic to something, but not peanuts`` () =
    allergicTo 5 Allergen.Peanuts |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for peanuts allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Peanuts |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for shellfish allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Shellfish |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for shellfish allergy - allergic only to shellfish`` () =
    allergicTo 4 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for shellfish allergy - allergic to shellfish and something else`` () =
    allergicTo 14 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for shellfish allergy - allergic to something, but not shellfish`` () =
    allergicTo 10 Allergen.Shellfish |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for shellfish allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Shellfish |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for strawberries allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for strawberries allergy - allergic only to strawberries`` () =
    allergicTo 8 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for strawberries allergy - allergic to strawberries and something else`` () =
    allergicTo 28 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for strawberries allergy - allergic to something, but not strawberries`` () =
    allergicTo 20 Allergen.Strawberries |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for strawberries allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Strawberries |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for tomatoes allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Tomatoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for tomatoes allergy - allergic only to tomatoes`` () =
    allergicTo 16 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for tomatoes allergy - allergic to tomatoes and something else`` () =
    allergicTo 56 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for tomatoes allergy - allergic to something, but not tomatoes`` () =
    allergicTo 40 Allergen.Tomatoes |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for tomatoes allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Tomatoes |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for chocolate allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Chocolate |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for chocolate allergy - allergic only to chocolate`` () =
    allergicTo 32 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for chocolate allergy - allergic to chocolate and something else`` () =
    allergicTo 112 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for chocolate allergy - allergic to something, but not chocolate`` () =
    allergicTo 80 Allergen.Chocolate |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for chocolate allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Chocolate |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for pollen allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Pollen |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for pollen allergy - allergic only to pollen`` () =
    allergicTo 64 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for pollen allergy - allergic to pollen and something else`` () =
    allergicTo 224 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for pollen allergy - allergic to something, but not pollen`` () =
    allergicTo 160 Allergen.Pollen |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for pollen allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Pollen |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for cats allergy - not allergic to anything`` () =
    allergicTo 0 Allergen.Cats |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for cats allergy - allergic only to cats`` () =
    allergicTo 128 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for cats allergy - allergic to cats and something else`` () =
    allergicTo 192 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for cats allergy - allergic to something, but not cats`` () =
    allergicTo 64 Allergen.Cats |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Testing for cats allergy - allergic to everything`` () =
    allergicTo 255 Allergen.Cats |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - no allergies`` () =
    list 0 |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - just eggs`` () =
    list 1 |> should equal [Allergen.Eggs]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - just peanuts`` () =
    list 2 |> should equal [Allergen.Peanuts]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - just strawberries`` () =
    list 8 |> should equal [Allergen.Strawberries]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - eggs and peanuts`` () =
    list 3 |> should equal [Allergen.Eggs; Allergen.Peanuts]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - more than eggs but not peanuts`` () =
    list 5 |> should equal [Allergen.Eggs; Allergen.Shellfish]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - lots of stuff`` () =
    list 248 |> should equal [Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - everything`` () =
    list 255 |> should equal [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - no allergen score parts`` () =
    list 509 |> should equal [Allergen.Eggs; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``List - no allergen score parts without highest valid score`` () =
    list 257 |> should equal [Allergen.Eggs]

