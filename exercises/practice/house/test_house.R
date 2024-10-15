source("./house.R")
library(testthat)

test_that("Verse one - the house that jack built", {
    let expected = ["This is the house that Jack built."]
  expect_equal(recite 1 1, expected)
})

test_that("Verse two - the malt that lay", {
    let expected = ["This is the malt that lay in the house that Jack built."]
  expect_equal(recite 2 2, expected)
})

test_that("Verse three - the rat that ate", {
    let expected = ["This is the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 3 3, expected)
})

test_that("Verse four - the cat that killed", {
    let expected = ["This is the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 4 4, expected)
})

test_that("Verse five - the dog that worried", {
    let expected = ["This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 5 5, expected)
})

test_that("Verse six - the cow with the crumpled horn", {
    let expected = ["This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 6 6, expected)
})

test_that("Verse seven - the maiden all forlorn", {
    let expected = ["This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 7 7, expected)
})

test_that("Verse eight - the man all tattered and torn", {
    let expected = ["This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 8 8, expected)
})

test_that("Verse nine - the priest all shaven and shorn", {
    let expected = ["This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 9 9, expected)
})

test_that("Verse 10 - the rooster that crowed in the morn", {
    let expected = ["This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 10 10, expected)
})

test_that("Verse 11 - the farmer sowing his corn", {
    let expected = ["This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 11 11, expected)
})

test_that("Verse 12 - the horse and the hound and the horn", {
    let expected = ["This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
  expect_equal(recite 12 12, expected)
})

test_that("Multiple verses", {
    let expected = 
        [ "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
  expect_equal(recite 4 8, expected)
})

test_that("Full rhyme", {
    let expected = 
        [ "This is the house that Jack built.";
          "This is the malt that lay in the house that Jack built.";
          "This is the rat that ate the malt that lay in the house that Jack built.";
          "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
  expect_equal(recite 1 12, expected)

