source("./allergies.R")
library(testthat)

test_that("Testing for eggs allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Eggs)
})

test_that("Testing for eggs allergy - allergic only to eggs", {
    expect_true(allergicTo 1 Allergen.Eggs)
})

test_that("Testing for eggs allergy - allergic to eggs and something else", {
    expect_true(allergicTo 3 Allergen.Eggs)
})

test_that("Testing for eggs allergy - allergic to something, but not eggs", {
    expect_false(allergicTo 2 Allergen.Eggs)
})

test_that("Testing for eggs allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Eggs)
})

test_that("Testing for peanuts allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Peanuts)
})

test_that("Testing for peanuts allergy - allergic only to peanuts", {
    expect_true(allergicTo 2 Allergen.Peanuts)
})

test_that("Testing for peanuts allergy - allergic to peanuts and something else", {
    expect_true(allergicTo 7 Allergen.Peanuts)
})

test_that("Testing for peanuts allergy - allergic to something, but not peanuts", {
    expect_false(allergicTo 5 Allergen.Peanuts)
})

test_that("Testing for peanuts allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Peanuts)
})

test_that("Testing for shellfish allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Shellfish)
})

test_that("Testing for shellfish allergy - allergic only to shellfish", {
    expect_true(allergicTo 4 Allergen.Shellfish)
})

test_that("Testing for shellfish allergy - allergic to shellfish and something else", {
    expect_true(allergicTo 14 Allergen.Shellfish)
})

test_that("Testing for shellfish allergy - allergic to something, but not shellfish", {
    expect_false(allergicTo 10 Allergen.Shellfish)
})

test_that("Testing for shellfish allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Shellfish)
})

test_that("Testing for strawberries allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Strawberries)
})

test_that("Testing for strawberries allergy - allergic only to strawberries", {
    expect_true(allergicTo 8 Allergen.Strawberries)
})

test_that("Testing for strawberries allergy - allergic to strawberries and something else", {
    expect_true(allergicTo 28 Allergen.Strawberries)
})

test_that("Testing for strawberries allergy - allergic to something, but not strawberries", {
    expect_false(allergicTo 20 Allergen.Strawberries)
})

test_that("Testing for strawberries allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Strawberries)
})

test_that("Testing for tomatoes allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Tomatoes)
})

test_that("Testing for tomatoes allergy - allergic only to tomatoes", {
    expect_true(allergicTo 16 Allergen.Tomatoes)
})

test_that("Testing for tomatoes allergy - allergic to tomatoes and something else", {
    expect_true(allergicTo 56 Allergen.Tomatoes)
})

test_that("Testing for tomatoes allergy - allergic to something, but not tomatoes", {
    expect_false(allergicTo 40 Allergen.Tomatoes)
})

test_that("Testing for tomatoes allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Tomatoes)
})

test_that("Testing for chocolate allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Chocolate)
})

test_that("Testing for chocolate allergy - allergic only to chocolate", {
    expect_true(allergicTo 32 Allergen.Chocolate)
})

test_that("Testing for chocolate allergy - allergic to chocolate and something else", {
    expect_true(allergicTo 112 Allergen.Chocolate)
})

test_that("Testing for chocolate allergy - allergic to something, but not chocolate", {
    expect_false(allergicTo 80 Allergen.Chocolate)
})

test_that("Testing for chocolate allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Chocolate)
})

test_that("Testing for pollen allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Pollen)
})

test_that("Testing for pollen allergy - allergic only to pollen", {
    expect_true(allergicTo 64 Allergen.Pollen)
})

test_that("Testing for pollen allergy - allergic to pollen and something else", {
    expect_true(allergicTo 224 Allergen.Pollen)
})

test_that("Testing for pollen allergy - allergic to something, but not pollen", {
    expect_false(allergicTo 160 Allergen.Pollen)
})

test_that("Testing for pollen allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Pollen)
})

test_that("Testing for cats allergy - not allergic to anything", {
    expect_false(allergicTo 0 Allergen.Cats)
})

test_that("Testing for cats allergy - allergic only to cats", {
    expect_true(allergicTo 128 Allergen.Cats)
})

test_that("Testing for cats allergy - allergic to cats and something else", {
    expect_true(allergicTo 192 Allergen.Cats)
})

test_that("Testing for cats allergy - allergic to something, but not cats", {
    expect_false(allergicTo 64 Allergen.Cats)
})

test_that("Testing for cats allergy - allergic to everything", {
    expect_true(allergicTo 255 Allergen.Cats)
})

test_that("List - no allergies", {
    list 0 |> should be Empty

test_that("List - just eggs", {
    expect_equal(list 1, c(Allergen.Eggs))
})

test_that("List - just peanuts", {
    expect_equal(list 2, c(Allergen.Peanuts))
})

test_that("List - just strawberries", {
    expect_equal(list 8, c(Allergen.Strawberries))
})

test_that("List - eggs and peanuts", {
    expect_equal(list 3, c(Allergen.Eggs, Allergen.Peanuts))
})

test_that("List - more than eggs but not peanuts", {
    expect_equal(list 5, c(Allergen.Eggs, Allergen.Shellfish))
})

test_that("List - lots of stuff", {
    expect_equal(list 248, c(Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats))
})

test_that("List - everything", {
    expect_equal(list 255, c(Allergen.Eggs, Allergen.Peanuts, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats))
})

test_that("List - no allergen score parts", {
    expect_equal(list 509, c(Allergen.Eggs, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats))
})

test_that("List - no allergen score parts without highest valid score", {
    expect_equal(list 257, c(Allergen.Eggs))
})
