source("./scale-generator.R")
library(testthat)

test_that("Chromatic scale with sharps", {
  expect_equal(chromatic "C", c("C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"))
})

test_that("Chromatic scale with flats", {
  expect_equal(chromatic "F", c("F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"))
})

test_that("Simple major scale", {
  expect_equal(interval "MMmMMMm" "C", c("C", "D", "E", "F", "G", "A", "B", "C"))
})

test_that("Major scale with sharps", {
  expect_equal(interval "MMmMMMm" "G", c("G", "A", "B", "C", "D", "E", "F#", "G"))
})

test_that("Major scale with flats", {
  expect_equal(interval "MMmMMMm" "F", c("F", "G", "A", "Bb", "C", "D", "E", "F"))
})

test_that("Minor scale with sharps", {
  expect_equal(interval "MmMMmMM" "f#", c("F#", "G#", "A", "B", "C#", "D", "E", "F#"))
})

test_that("Minor scale with flats", {
  expect_equal(interval "MmMMmMM" "bb", c("Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"))
})

test_that("Dorian mode", {
  expect_equal(interval "MmMMMmM" "d", c("D", "E", "F", "G", "A", "B", "C", "D"))
})

test_that("Mixolydian mode", {
  expect_equal(interval "MMmMMmM" "Eb", c("Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"))
})

test_that("Lydian mode", {
  expect_equal(interval "MMMmMMm" "a", c("A", "B", "C#", "D#", "E", "F#", "G#", "A"))
})

test_that("Phrygian mode", {
  expect_equal(interval "mMMMmMM" "e", c("E", "F", "G", "A", "B", "C", "D", "E"))
})

test_that("Locrian mode", {
  expect_equal(interval "mMMmMMM" "g", c("G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"))
})

test_that("Harmonic minor", {
  expect_equal(interval "MmMMmAm" "d", c("D", "E", "F", "G", "A", "Bb", "Db", "D"))
})

test_that("Octatonic", {
  expect_equal(interval "MmMmMmMm" "C", c("C", "D", "D#", "F", "F#", "G#", "A", "B", "C"))
})

test_that("Hexatonic", {
  expect_equal(interval "MMMMMM" "Db", c("Db", "Eb", "F", "G", "A", "B", "Db"))
})

test_that("Pentatonic", {
  expect_equal(interval "MMAMA" "A", c("A", "B", "C#", "E", "F#", "A"))
})

test_that("Enigmatic", {
  expect_equal(interval "mAMMMmm" "G", c("G", "G#", "B", "C#", "D#", "F", "F#", "G"))
})
