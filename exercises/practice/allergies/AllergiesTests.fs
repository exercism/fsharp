source("./allergies.R")
library(testthat)

let ``Testing for eggs allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Eggs, false)

let ``Testing for eggs allergy - allergic only to eggs`` () =
    expect_equal(allergicTo 1 Allergen.Eggs, true)

let ``Testing for eggs allergy - allergic to eggs and something else`` () =
    expect_equal(allergicTo 3 Allergen.Eggs, true)

let ``Testing for eggs allergy - allergic to something, but not eggs`` () =
    expect_equal(allergicTo 2 Allergen.Eggs, false)

let ``Testing for eggs allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Eggs, true)

let ``Testing for peanuts allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Peanuts, false)

let ``Testing for peanuts allergy - allergic only to peanuts`` () =
    expect_equal(allergicTo 2 Allergen.Peanuts, true)

let ``Testing for peanuts allergy - allergic to peanuts and something else`` () =
    expect_equal(allergicTo 7 Allergen.Peanuts, true)

let ``Testing for peanuts allergy - allergic to something, but not peanuts`` () =
    expect_equal(allergicTo 5 Allergen.Peanuts, false)

let ``Testing for peanuts allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Peanuts, true)

let ``Testing for shellfish allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Shellfish, false)

let ``Testing for shellfish allergy - allergic only to shellfish`` () =
    expect_equal(allergicTo 4 Allergen.Shellfish, true)

let ``Testing for shellfish allergy - allergic to shellfish and something else`` () =
    expect_equal(allergicTo 14 Allergen.Shellfish, true)

let ``Testing for shellfish allergy - allergic to something, but not shellfish`` () =
    expect_equal(allergicTo 10 Allergen.Shellfish, false)

let ``Testing for shellfish allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Shellfish, true)

let ``Testing for strawberries allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Strawberries, false)

let ``Testing for strawberries allergy - allergic only to strawberries`` () =
    expect_equal(allergicTo 8 Allergen.Strawberries, true)

let ``Testing for strawberries allergy - allergic to strawberries and something else`` () =
    expect_equal(allergicTo 28 Allergen.Strawberries, true)

let ``Testing for strawberries allergy - allergic to something, but not strawberries`` () =
    expect_equal(allergicTo 20 Allergen.Strawberries, false)

let ``Testing for strawberries allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Strawberries, true)

let ``Testing for tomatoes allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Tomatoes, false)

let ``Testing for tomatoes allergy - allergic only to tomatoes`` () =
    expect_equal(allergicTo 16 Allergen.Tomatoes, true)

let ``Testing for tomatoes allergy - allergic to tomatoes and something else`` () =
    expect_equal(allergicTo 56 Allergen.Tomatoes, true)

let ``Testing for tomatoes allergy - allergic to something, but not tomatoes`` () =
    expect_equal(allergicTo 40 Allergen.Tomatoes, false)

let ``Testing for tomatoes allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Tomatoes, true)

let ``Testing for chocolate allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Chocolate, false)

let ``Testing for chocolate allergy - allergic only to chocolate`` () =
    expect_equal(allergicTo 32 Allergen.Chocolate, true)

let ``Testing for chocolate allergy - allergic to chocolate and something else`` () =
    expect_equal(allergicTo 112 Allergen.Chocolate, true)

let ``Testing for chocolate allergy - allergic to something, but not chocolate`` () =
    expect_equal(allergicTo 80 Allergen.Chocolate, false)

let ``Testing for chocolate allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Chocolate, true)

let ``Testing for pollen allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Pollen, false)

let ``Testing for pollen allergy - allergic only to pollen`` () =
    expect_equal(allergicTo 64 Allergen.Pollen, true)

let ``Testing for pollen allergy - allergic to pollen and something else`` () =
    expect_equal(allergicTo 224 Allergen.Pollen, true)

let ``Testing for pollen allergy - allergic to something, but not pollen`` () =
    expect_equal(allergicTo 160 Allergen.Pollen, false)

let ``Testing for pollen allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Pollen, true)

let ``Testing for cats allergy - not allergic to anything`` () =
    expect_equal(allergicTo 0 Allergen.Cats, false)

let ``Testing for cats allergy - allergic only to cats`` () =
    expect_equal(allergicTo 128 Allergen.Cats, true)

let ``Testing for cats allergy - allergic to cats and something else`` () =
    expect_equal(allergicTo 192 Allergen.Cats, true)

let ``Testing for cats allergy - allergic to something, but not cats`` () =
    expect_equal(allergicTo 64 Allergen.Cats, false)

let ``Testing for cats allergy - allergic to everything`` () =
    expect_equal(allergicTo 255 Allergen.Cats, true)

let ``List - no allergies`` () =
    list 0 |> should be Empty

let ``List - just eggs`` () =
    expect_equal(list 1, [Allergen.Eggs])

let ``List - just peanuts`` () =
    expect_equal(list 2, [Allergen.Peanuts])

let ``List - just strawberries`` () =
    expect_equal(list 8, [Allergen.Strawberries])

let ``List - eggs and peanuts`` () =
    expect_equal(list 3, [Allergen.Eggs; Allergen.Peanuts])

let ``List - more than eggs but not peanuts`` () =
    expect_equal(list 5, [Allergen.Eggs; Allergen.Shellfish])

let ``List - lots of stuff`` () =
    expect_equal(list 248, [Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats])

let ``List - everything`` () =
    expect_equal(list 255, [Allergen.Eggs; Allergen.Peanuts; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats])

let ``List - no allergen score parts`` () =
    expect_equal(list 509, [Allergen.Eggs; Allergen.Shellfish; Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats])

let ``List - no allergen score parts without highest valid score`` () =
    expect_equal(list 257, [Allergen.Eggs])

