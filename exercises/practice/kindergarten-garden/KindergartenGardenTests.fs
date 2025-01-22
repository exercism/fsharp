source("./kindergarten-garden.R")
library(testthat)

test_that("Partial garden - garden with single student", {
    student <- "Alice"
    diagram <- "RC\nGG"
    expected <- c(Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Partial garden - different garden with single student", {
    student <- "Alice"
    diagram <- "VC\nRC"
    expected <- c(Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Partial garden - garden with two students", {
    student <- "Bob"
    diagram <- "VVCG\nVVRC"
    expected <- c(Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Partial garden - multiple students for the same garden with three students - second student's garden", {
    student <- "Bob"
    diagram <- "VVCCGG\nVVCCGG"
    expected <- c(Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Partial garden - multiple students for the same garden with three students - third student's garden", {
    student <- "Charlie"
    diagram <- "VVCCGG\nVVCCGG"
    expected <- c(Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Alice, first student's garden", {
    student <- "Alice"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Bob, second student's garden", {
    student <- "Bob"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Charlie", {
    student <- "Charlie"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for David", {
    student <- "David"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Eve", {
    student <- "Eve"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Fred", {
    student <- "Fred"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Ginny", {
    student <- "Ginny"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Harriet", {
    student <- "Harriet"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Ileana", {
    student <- "Ileana"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Joseph", {
    student <- "Joseph"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Kincaid, second to last student's garden", {
    student <- "Kincaid"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass)
    expect_equal(plants(diagram, student), expected)
})

test_that("Full garden - for Larry, last student's garden", {
    student <- "Larry"
    diagram <- "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    expected <- c(Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets)
    expect_equal(plants(diagram, student), expected)
})
