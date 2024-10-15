source("./kindergarten-garden.R")
library(testthat)

test_that("Partial garden - garden with single student", {
    let student = "Alice"
    let diagram = "RC\nGG"
  expected <- c(Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Partial garden - different garden with single student", {
    let student = "Alice"
    let diagram = "VC\nRC"
  expected <- c(Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Partial garden - garden with two students", {
    let student = "Bob"
    let diagram = "VVCG\nVVRC"
  expected <- c(Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Partial garden - multiple students for the same garden with three students - second student's garden", {
    let student = "Bob"
    let diagram = "VVCCGG\nVVCCGG"
  expected <- c(Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Partial garden - multiple students for the same garden with three students - third student's garden", {
    let student = "Charlie"
    let diagram = "VVCCGG\nVVCCGG"
  expected <- c(Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Alice, first student's garden", {
    let student = "Alice"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Bob, second student's garden", {
    let student = "Bob"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Charlie", {
    let student = "Charlie"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for David", {
    let student = "David"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Eve", {
    let student = "Eve"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Fred", {
    let student = "Fred"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Ginny", {
    let student = "Ginny"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Harriet", {
    let student = "Harriet"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Ileana", {
    let student = "Ileana"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Joseph", {
    let student = "Joseph"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Kincaid, second to last student's garden", {
    let student = "Kincaid"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass)
  expect_equal(plants diagram student, expected)
})

test_that("Full garden - for Larry, last student's garden", {
    let student = "Larry"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
  expected <- c(Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets)
  expect_equal(plants diagram student, expected)
})